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
    currentPlayerTurn: Player,
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined,
}

const initialState: BoardSlice = {
    activeFigure: undefined,
    currentPlayerTurn: Player.White,
    Squares: Squares,
    Figures: new Array<IFigure>(),
    PionPromotion: undefined
}

interface IPionPromotion {
    ShowPionPromotionAlert: boolean
    ActivePion: IFigure
}

interface ClickSquare {
    square: ISquare
}

// First, create the thunk
export const fetchStandardBoard = createAsyncThunk(
    'board/fetchStandardBoard',
    async () => {
        const response = await boardAPI.fetchStandardBoard()
        return response.figures
    }
)

// First, create the thunk
export const fetchUserById = createAsyncThunk(
    'users/fetchByIdStatus',
    async (userId: string, thunkAPI) => {
        console.log("fetchUserById")
        const response = await userAPI.fetchById(userId)
        console.log(response)
        return response.data
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
            const clickedSquare = action.payload.square;
            const isValidClick = state.activeFigure?.EnableMoves?.some(eM => eM.Name === clickedSquare.Name)

            //PionPromotion
            if (clickedSquare.Row == RowLine.Eight) state.PionPromotion = { ShowPionPromotionAlert: true, ActivePion: state.activeFigure } as IPionPromotion
            

            state.activeFigure = undefined;
        },
        pionPromotion: (state, action: PayloadAction<FigureType>) => {
            state.Figures.find(f => f.Id === state.PionPromotion!.ActivePion.Id)!.Type = action.payload
            state.PionPromotion = undefined;
        },
    },
    extraReducers: (builder) => {
        // Add reducers for additional action types here, and handle loading state as needed
        builder.addCase(fetchStandardBoard.fulfilled, (state, action: PayloadAction<Array<IFigure>>) => {
            console.log("standardBoard loaded")
            state.Figures = action.payload;
        });
        builder.addCase(fetchUserById.fulfilled, (state, action) => {
            // Add user to the state array
            
            console.log("extraReducers")
            return state;
        })
    }
})

export const { click, release, pionPromotion } = boardSlice.actions

export default boardSlice.reducer