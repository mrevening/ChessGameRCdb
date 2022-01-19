import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import ISquare from 'board/interface/ISquare'
import IFigure from 'board/interface/IFigure'
import { Squares } from 'board/repository/Squares'
import { boardAPI } from './api/boardAPI'
import { FigureType } from './board/enum/FigureType'
import { RowLine } from './board/enum/RowLine'

interface BoardSlice {
    activeFigure: IFigure | undefined,
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined,
    destinationSquare: ISquare | undefined,
    isValidMove: boolean | undefined
}

const initialState: BoardSlice = {
    activeFigure: undefined,
    Squares: Squares,
    Figures: new Array<IFigure>(),
    PionPromotion: undefined,
    destinationSquare: undefined,
    isValidMove: undefined
}

interface IPionPromotion {
    ShowPionPromotionAlert: boolean
    ActivePion: IFigure
}

interface ClickSquare {
    square: ISquare
}

export interface ISaveMove {
    startSquare: ISquare,
    endSquare: ISquare
}

export const getBoard = createAsyncThunk(
    'board/getBoard',
    async () => {
        const response = await boardAPI.getBoard()
        return response.figures
    }
)

export const executeMove = createAsyncThunk(
    'board/executeMove',
    async (square: ISquare, thunkAPI) => {
        const { board } = thunkAPI.getState() as { board: BoardSlice }
        if (board.isValidMove)
            thunkAPI.dispatch(saveMove()).then(() => thunkAPI.dispatch(getBoard()), null);
    }
)

const saveMove = createAsyncThunk(
    'board/saveMove',
    async (_, thunkAPI) => {
        const { board } = thunkAPI.getState() as { board: BoardSlice }
        await boardAPI.saveMove({ startSquare: board.activeFigure!.Square, endSquare: board.destinationSquare! })
    },
    {
        condition: (_, { getState }) => {
            const { board } = getState() as { board: BoardSlice }
            return board.destinationSquare !== undefined
        },
    }
)

export const boardSlice = createSlice({
    name: 'board',
    initialState,
    reducers: {
        click: (state, action: PayloadAction<ClickSquare>) => {
            console.log("click")
            const clickedSquare = action.payload.square;
            state.activeFigure = state.Figures.find(f => f.Square.Id === clickedSquare.Id);
        },
        release: (state, action: PayloadAction<ClickSquare>) => {
            console.log("relase")
            const clickedSquare = action.payload.square
            const isValidMove = state.activeFigure?.EnableMoves?.some(eM => eM.Name === clickedSquare.Name)!
            state.isValidMove = isValidMove
            if (!isValidMove) {
                state.activeFigure = undefined;
                return
            }
            state.destinationSquare = clickedSquare
            const figure = state.Figures.find(x => x.Square.Name === state.activeFigure!.Square.Name)
            figure!.Square = clickedSquare


            //if (state.destinationSquare?.Row == RowLine.Eight) state.PionPromotion = { ShowPionPromotionAlert: true, ActivePion: state.activeFigure } as IPionPromotion
        },
        pionPromotion: (state, action: PayloadAction<FigureType>) => {
            state.Figures.find(f => f.Id === state.PionPromotion!.ActivePion.Id)!.Type = action.payload
            state.PionPromotion = undefined;
        },
    },
    extraReducers: (builder) => {
        builder.addCase(getBoard.fulfilled, (state, action: PayloadAction<Array<IFigure>>) => {
            state.Figures = action.payload;
            state.activeFigure = undefined;
            state.destinationSquare = undefined;
            state.isValidMove = undefined;
        });
        builder.addCase(executeMove.fulfilled, (state, action) => {


        });
        builder.addCase(executeMove.rejected, (state, action) => {


        });
        builder.addCase(saveMove.fulfilled, (state, action) => {

        });
        builder.addCase(saveMove.rejected, (state, action) => {

        });
    }
})

export const { click, release, pionPromotion } = boardSlice.actions

export default boardSlice.reducer