import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import ISquare from 'board/interface/ISquare'
import IFigure from 'board/interface/IFigure'
import { Squares } from 'board/repository/Squares'
import { boardAPI } from './api/boardAPI'
import { FigureType } from './board/enum/FigureType'


interface BoardSlice {
    activeFigure: IFigure | undefined,
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined,
    destinationSquare: ISquare | undefined
}

const initialState: BoardSlice = {
    activeFigure: undefined,
    Squares: Squares,
    Figures: new Array<IFigure>(),
    PionPromotion: undefined,
    destinationSquare: undefined,
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

export const fetchStandardBoard = createAsyncThunk(
    'board/fetchStandardBoard',
    async () => {
        const response = await boardAPI.fetchStandardBoard()
        return response.figures
    }
)

export const saveMove = createAsyncThunk(
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
            const clickedSquare = action.payload.square;
            state.activeFigure = state.Figures.find(f => f.Square.Id === clickedSquare.Id);
        },
        release: (state, action: PayloadAction<ClickSquare>) => {
            const clickedSquare = action.payload.square
            const isValidMove = state.activeFigure!.EnableMoves?.some(eM => eM.Name === clickedSquare.Name)!

            if (!isValidMove) {
                state.activeFigure = undefined;
                return
            }
            state.destinationSquare = clickedSquare
            //if (state.destinationSquare?.Row == RowLine.Eight) state.PionPromotion = { ShowPionPromotionAlert: true, ActivePion: state.activeFigure } as IPionPromotion
            const figure = state.Figures.find(x => x.Square.Name === state.activeFigure!.Square.Name)
            figure!.Square = clickedSquare
        },
        pionPromotion: (state, action: PayloadAction<FigureType>) => {
            state.Figures.find(f => f.Id === state.PionPromotion!.ActivePion.Id)!.Type = action.payload
            state.PionPromotion = undefined;
        },
    },
    extraReducers: (builder) => {
        builder.addCase(fetchStandardBoard.fulfilled, (state, action: PayloadAction<Array<IFigure>>) => {
            state.Figures = action.payload;
        });
        builder.addCase(saveMove.fulfilled, (state, action) => {
            state.activeFigure = undefined;
            state.destinationSquare = undefined;

        });
        builder.addCase(saveMove.rejected, (state, action) => {
            state.activeFigure = undefined;
            state.destinationSquare = undefined;
        });
    }
})

export const { click, release, pionPromotion } = boardSlice.actions

export default boardSlice.reducer