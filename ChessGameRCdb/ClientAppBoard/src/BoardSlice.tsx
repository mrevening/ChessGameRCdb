import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import ISquare from 'board/interface/ISquare'
import IFigure from 'board/interface/IFigure'
import { Player } from 'board/enum/Player'
import { Squares } from 'board/repository/Squares'
import { userAPI } from './api/userAPI'
import { boardAPI } from './api/boardAPI'
import { RowLine } from './board/enum/RowLine'
import { FigureType } from './board/enum/FigureType'


interface BoardSlice {
    activeFigure: IFigure | undefined,
    //currentPlayerTurn: Player,
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined,
    destinationSquare: ISquare | undefined
    isValidMove: boolean
}

const initialState: BoardSlice = {
    activeFigure: undefined,
    //currentPlayerTurn: Player.White,
    Squares: Squares,
    Figures: new Array<IFigure>(),
    PionPromotion: undefined,
    destinationSquare: undefined,
    isValidMove: false
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
        const startSquare = board.activeFigure!.Square
        const endSquare = board.destinationSquare!
        await boardAPI.saveMove({ startSquare: startSquare, endSquare: endSquare })
    },
    {
        condition: (_, { getState }) => {
            const { board } = getState() as { board: BoardSlice }
            return board.isValidMove
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
            console.log("release")
            const clickedSquare = action.payload.square
            const activeFigure = state.activeFigure!
            state.destinationSquare = clickedSquare

            const isEmptyMove = activeFigure.Square === clickedSquare
            if (isEmptyMove) return

            const isValidMove = activeFigure.EnableMoves?.some(eM => eM.Name === clickedSquare.Name)!
            state.isValidMove = isValidMove

            if (!isValidMove) return;
            //if (state.destinationSquare?.Row == RowLine.Eight) state.PionPromotion = { ShowPionPromotionAlert: true, ActivePion: state.activeFigure } as IPionPromotion
            const figure = state.Figures.find(x => x.Square.Name === activeFigure.Square.Name)
            figure!.Square = clickedSquare
        },
        pionPromotion: (state, action: PayloadAction<FigureType>) => {
            state.Figures.find(f => f.Id === state.PionPromotion!.ActivePion.Id)!.Type = action.payload
            state.PionPromotion = undefined;
        },
    },
    extraReducers: (builder) => {
        builder.addCase(fetchStandardBoard.fulfilled, (state, action: PayloadAction<Array<IFigure>>) => {
            console.log("standardBoard loaded")
            state.Figures = action.payload;
        });
        builder.addCase(saveMove.fulfilled, (state, action) => {
            state.activeFigure = undefined;
            state.destinationSquare = undefined;
            state.activeFigure = undefined;
            state.PionPromotion = undefined;

        });
        builder.addCase(saveMove.rejected, (state, action) => {
            state.activeFigure = undefined;
            state.destinationSquare = undefined;
            state.activeFigure = undefined;
            state.PionPromotion = undefined;
        });
    }
})

export const { click, release, pionPromotion } = boardSlice.actions

export default boardSlice.reducer