import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import ISquare from './interface/ISquare'
import IFigure from './interface/IFigure'
import { Squares } from './repository/Squares'
import { BoardAPI } from './api/BoardAPI'
import { FigureType } from './enum/FigureType'
import { FigureDTO } from './api/dto/FigureDTO'
import IBoardSlice from './interface/IBoardSlice'
import { PlayerColor } from './enum/PlayerColor'

const initialState: IBoardSlice = {
    currentPlayerTurn: PlayerColor.White,
    activeFigure: undefined,
    Squares: Squares,
    Figures: new Array<IFigure>(),
    PionPromotion: undefined,
    destinationSquare: undefined,
    isValidMove: undefined,
    playerId: undefined,
    gameId: 0
}

interface ClickSquare {
    square: ISquare
}

interface IMove {
    board: FigureDTO[]
}

export const getBoard = createAsyncThunk(
    'board/getBoard',
    async (gameId: number, thunkAPI) => {
        const response = await BoardAPI.getBoard(gameId)
        return response.figures
    }
)

export const executeMove = createAsyncThunk(
    'board/executeMove',
    async (square: ISquare, thunkAPI) => {
        const { board } = thunkAPI.getState() as { board: IBoardSlice }
        if (board.isValidMove)
            thunkAPI.dispatch(saveMove()).then(() => thunkAPI.dispatch(getBoard(board.gameId)), null);
    }
)

const saveMove = createAsyncThunk(
    'board/saveMove',
    async (_, thunkAPI) => {
        const { board } = thunkAPI.getState() as { board: IBoardSlice }
        await BoardAPI.saveMove({ gameId: board.gameId, startSquare: board.activeFigure!.Square, endSquare: board.destinationSquare! })
    },
    {
        condition: (_, { getState }) => {
            const { board } = getState() as { board: IBoardSlice }
            return board.destinationSquare !== undefined
        },
    }
)

export const boardSlice = createSlice({
    name: 'board',
    initialState,
    reducers: {
        addGameId: (state, action: PayloadAction<number>) => {
            state.gameId = action.payload
        },
        click: (state, action: PayloadAction<ClickSquare>) => {
            console.log(state.playerId)
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
        updateBoard: (state, action: PayloadAction<IMove>) => {
            console.log("updateBoard")
            const { board } = action.payload;
            var result = board.map((figure, i) => ({
                Id: i,
                Player: figure.player,
                Type: figure.type,
                Square: Squares.find(square => square.Name === figure.square) as ISquare,
                EnableMoves: figure.possibleMoves?.map(eM => Squares.find(square => square.Name === eM) as ISquare)
            } as IFigure))

            state.Figures = result
        },
    },
    extraReducers: (builder) => {
        builder.addCase(getBoard.fulfilled, (state, action: PayloadAction<Array<IFigure>>) => {
            state.activeFigure = undefined;
            state.destinationSquare = undefined;
            state.isValidMove = undefined;
            state.Figures = action.payload
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

export const { addGameId, click, release, pionPromotion, updateBoard } = boardSlice.actions

export default boardSlice.reducer