import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import { BoardAPI } from './api/boardAPI/BoardAPI'
import { GameAPI } from './api/gameAPI/GameAPI'
import { FigureDTO } from './api/boardAPI/dto/FigureDTO'
import { PlayerColor } from './board/enum/PlayerColor'
import IFigure from './board/interface/IFigure'
import ISquare from './board/interface/ISquare'
import { Squares } from './board/repository/Squares'
import IGameSlice from './IGameSlice'
import { FigureType } from './board/enum/FigureType'
import { ICreateGameRequestDTO } from './api/gameAPI/dto/ICreateGameRequestDTO'
import { ICreateGameResponseDTO } from './api/gameAPI/dto/ICreateGameResponseDTO'
import { IJoinGameRequestDTO } from './api/gameAPI/dto/IJoinGameRequestDTO'
import { IJoinGameResponseDTO } from './api/gameAPI/dto/IJoinGameResponseDTO'

const initialState: IGameSlice = {
    status: {
        gameId: undefined,
        hostId: undefined,
        guestId: undefined,
        thisPlayer: undefined,
        oponent: undefined
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
    game: FigureDTO[]
}

export const createNewGame = createAsyncThunk(
    'game/createNewGame',
    async (request: ICreateGameRequestDTO) => {
        var result = await GameAPI.createNewGame(request)
        result.response.hostId = request.hostId
        result.response.hostColor = request.hostColor
        return result.response
    }
)

export const joinGame = createAsyncThunk(
    'game/joinGame',
    async (request: IJoinGameRequestDTO) => {
        var result = await GameAPI.joinGame(request)
        return result.response
    }
)

export const getBoard = createAsyncThunk(
    'game/getBoard',
    async (gameId: number, thunkAPI) => {
        const response = await BoardAPI.getBoard(gameId)
        return response.figures
    }
)

export const executeMove = createAsyncThunk(
    'game/executeMove',
    async (square: ISquare, thunkAPI) => {
        const { game } = thunkAPI.getState() as { game: IGameSlice }
        if (game.board.isValidMove)
            thunkAPI.dispatch(saveMove()).then(() => thunkAPI.dispatch(getBoard(game.status.gameId!)), null);
    }
)

const saveMove = createAsyncThunk(
    'game/saveMove',
    async (_, thunkAPI) => {
        const { game } = thunkAPI.getState() as { game: IGameSlice }
        await BoardAPI.saveMove({ gameId: game.status.gameId!, startSquare: game.board.activeFigure!.Square, endSquare: game.board.destinationSquare! })
    },
    {
        condition: (_, { getState }) => {
            const { game } = getState() as { game: IGameSlice }
            return game.board.destinationSquare !== undefined
        },
    }
)

export const gameSlice = createSlice({
    name: 'game',
    initialState,
    reducers: {
        click: (state, action: PayloadAction<ClickSquare>) => {
            const clickedSquare = action.payload.square;
            var figure = state.board.Figures.find(f => f.Square.Id === clickedSquare.Id);
            if (figure && figure.Color !== state.status.thisPlayer?.playerColor) return
            state.board.activeFigure = figure
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
            console.log("updateGame")
            const { game } = action.payload;
            var result = game.map((figure, i) => ({
                Id: i,
                Color: figure.player,
                Type: figure.type,
                Square: Squares.find(square => square.Name === figure.square) as ISquare,
                EnableMoves: figure.possibleMoves?.map(eM => Squares.find(square => square.Name === eM) as ISquare)
            } as IFigure))

            state.board.Figures = result
        },
    },
    extraReducers: (builder) => {
        builder.addCase(createNewGame.fulfilled, (state, action: PayloadAction<ICreateGameResponseDTO>) => {
            var oponnentColor = action.payload.hostColor !== PlayerColor.White ? PlayerColor.White : PlayerColor.Black
            state.status.gameId = action.payload.gameId
            state.status.thisPlayer = { playerId: action.payload.hostId, playerColor: action.payload.hostColor }
            state.status.oponent = { playerId: undefined, playerColor: oponnentColor }
            state.status.hostId = action.payload.hostId
        });
        builder.addCase(joinGame.fulfilled, (state, action: PayloadAction<IJoinGameResponseDTO>) => {
            var color = action.payload.hostColorId !== PlayerColor.White ? PlayerColor.White : PlayerColor.Black
            state.status.gameId = action.payload.gameId
            state.status.thisPlayer = { playerId: action.payload.guestId, playerColor: color }
            state.status.oponent = { playerId: action.payload.hostId, playerColor: action.payload.hostColorId }
            state.status.hostId = action.payload.hostId
            state.status.guestId = action.payload.guestId
        });

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

export const { click, release, pionPromotion, updateBoard } = gameSlice.actions

export default gameSlice.reducer