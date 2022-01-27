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
    game: {
        gameId: undefined,
        playerId: undefined
    },
    board: {
        currentPlayerTurn: PlayerColor.White,
        activeFigure: undefined,
        Squares: Squares,
        Figures: new Array<IFigure>(),
        PionPromotion: undefined,
        destinationSquare: undefined,
        isValidMove: undefined,
    }
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
        if (board.board.isValidMove)
            thunkAPI.dispatch(saveMove()).then(() => thunkAPI.dispatch(getBoard(board.game.gameId!)), null);
    }
)

const saveMove = createAsyncThunk(
    'board/saveMove',
    async (_, thunkAPI) => {
        const { board } = thunkAPI.getState() as { board: IBoardSlice }
        await BoardAPI.saveMove({ gameId: board.game.gameId!, startSquare: board.board.activeFigure!.Square, endSquare: board.board.destinationSquare! })
    },
    {
        condition: (_, { getState }) => {
            const { board } = getState() as { board: IBoardSlice }
            return board.board.destinationSquare !== undefined
        },
    }
)

export const boardSlice = createSlice({
    name: 'board',
    initialState,
    reducers: {
        addGameId: (state, action: PayloadAction<number>) => {
            state.game.gameId = action.payload
        },
        click: (state, action: PayloadAction<ClickSquare>) => {
            const clickedSquare = action.payload.square;
            state.board.activeFigure = state.board.Figures.find(f => f.Square.Id === clickedSquare.Id);
        },
        release: (state, action: PayloadAction<ClickSquare>) => {
            console.log("relase")
            const clickedSquare = action.payload.square
            const isValidMove = state.board.activeFigure?.EnableMoves?.some(eM => eM.Name === clickedSquare.Name)!
            state.board.isValidMove = isValidMove
            if (!isValidMove) {
                state.board.activeFigure = undefined;
                return
            }
            state.board.destinationSquare = clickedSquare
            const figure = state.board.Figures.find(x => x.Square.Name === state.board.activeFigure!.Square.Name)
            figure!.Square = clickedSquare


            //if (state.destinationSquare?.Row == RowLine.Eight) state.PionPromotion = { ShowPionPromotionAlert: true, ActivePion: state.activeFigure } as IPionPromotion
        },
        pionPromotion: (state, action: PayloadAction<FigureType>) => {
            state.board.Figures.find(f => f.Id === state.board.PionPromotion!.ActivePion.Id)!.Type = action.payload
            state.board.PionPromotion = undefined;
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

            state.board.Figures = result
        },
    },
    extraReducers: (builder) => {
        builder.addCase(getBoard.fulfilled, (state, action: PayloadAction<Array<IFigure>>) => {
            state.board.activeFigure = undefined;
            state.board.destinationSquare = undefined;
            state.board.isValidMove = undefined;
            state.board.Figures = action.payload
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