import { createSlice, PayloadAction, createAsyncThunk, current } from '@reduxjs/toolkit'
import { BoardAPI } from '../api/BoardAPI'
import { GameAPI } from '../api/GameAPI'
import { PlayerColor } from '../repository/enum/PlayerColor'
import { FigureType } from '../repository/enum/FigureType'
import IGameSlice from '../interfaces/game/IGameSlice'
import { ICreateGameRequestDTO } from '../dto/CreateGame/ICreateGameRequestDTO'
import { IJoinGameRequestDTO } from '../dto/JoinGame/IJoinGameRequestDTO'
import ISquare from '../interfaces/board/ISquare'
import { IUpdateBoardDTO } from '../dto/IUpdateBoardDTO'
import { Role } from '../repository/enum/Role'
import { ICreateGameResponseDTO } from '../dto/CreateGame/ICreateGameResponseDTO'
import { IJoinGameResponseDTO } from '../dto/JoinGame/IJoinGameResponseDTO'
import { IGetBoardResponseDTO } from '../dto/GetBoard/IGetBoardResponseDTO'
import { Squares } from '../repository/Squares'
import { ActionType, ActionTypeEnum } from '../repository/enum/ActionType'
import { IGetBoardRequestDTO } from '../dto/GetBoard/IGetBoardRequestDTO'

const initialState: IGameSlice = {
    status: {
        gameId: undefined,
        thisPlayer: undefined,
        opponent: undefined,
        currentPlayerTurn: PlayerColor.White,
    },
    board: {
        squares: Squares,
        figures: undefined,
        activeFigure: undefined,
        isValidMove: undefined,
        destinationSquare: undefined,
        move: undefined,
        pionPromotion: undefined
    }
}

interface ClickSquare {
    square: ISquare
}

interface IUpdateUserInfo {
    id: string
    name: string
    token: string
}

export const createNewGame = createAsyncThunk(
    'game/createNewGame',
    async (request: ICreateGameRequestDTO) => {
        var result = await GameAPI.createNewGame(request)
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
    async (request: IGetBoardRequestDTO) => {
        const result = await BoardAPI.getBoard(request)
        return result.response
    }
)

export const executeMove = createAsyncThunk(
    'game/executeMove',
    async (_, thunkAPI) => {
        const { game } = thunkAPI.getState() as { game: IGameSlice }
        if (game.board.isValidMove)
            await BoardAPI.executeMove({ gameId: game.status.gameId!, figures: game.board.figures!, move: game.board.move! })
        return
    }
)

const saveMove = createAsyncThunk(
    'game/saveMove',
    async (_, thunkAPI) => {
        const { game } = thunkAPI.getState() as { game: IGameSlice }
        await BoardAPI.saveMove({ gameId: game.status.gameId!, startSquare: game.board.activeFigure!.square, endSquare: game.board.destinationSquare!.name })
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
            var s = current(state)
            const clickedSquare = action.payload.square;
            var figure = s.board.figures?.find(f => f.square === clickedSquare.name);
            if (figure && figure.color !== s.status.thisPlayer?.color) return
            state.board.activeFigure = figure
        },
        release: (state, action: PayloadAction<ClickSquare>) => {
            var s = current(state)
            const clickedSquare = action.payload.square
            const isValidMove = s.board.activeFigure?.enableMoves?.some(eM => eM.log?.end === clickedSquare.name)!
            if (!isValidMove) return
            state.board.isValidMove = true
            state.board.destinationSquare = clickedSquare
            var move = s.board.activeFigure?.enableMoves?.find(x => x.log.end === clickedSquare.name)
            if (move === null) console.log('null')
            state.board.move = move
            //var actionType = move.action as ActionType
            if (move.action.id === ActionTypeEnum.Promotion || move.action.id === ActionTypeEnum.PromotionWithCapture) state.board.pionPromotion = { showPionPromotionAlert: true, activePion: state.board.activeFigure }
        },
        pionPromotion: (state, action: PayloadAction<FigureType>) => {
            if( state.board.figures) state.board.figures.find(f => f.square === state.board.pionPromotion!.activePion.square)!.type = action.payload
            state.board.pionPromotion = undefined;
        },
        updateBoard: (state, action: PayloadAction<IUpdateBoardDTO>) => {
            console.log("updateGame")
            const board = action.payload.board;
            state.board.figures = board
        },
        updateGuestInfo: (state, action: PayloadAction<IUpdateUserInfo>) => {
            var guestColor = state.status.thisPlayer?.color !== PlayerColor.White ? PlayerColor.White : PlayerColor.Black
            state.status.opponent = {
                id: action.payload.id,
                name: action.payload.name,
                token: action.payload.token,
                color: guestColor,
                role: Role.Guest
            }
        },
    },
    extraReducers: (builder) => {
        builder.addCase(createNewGame.fulfilled, (state, action: PayloadAction<ICreateGameResponseDTO>) => {
            state.status.gameId = action.payload.gameId
            state.status.thisPlayer = { id: action.payload.hostId, name: action.payload.hostName, token: action.payload.hostToken, color: action.payload.hostColor, role: Role.Host }
        });
        builder.addCase(joinGame.fulfilled, (state, action: PayloadAction<IJoinGameResponseDTO>) => {
            var guestColor = action.payload.hostColorId !== PlayerColor.White ? PlayerColor.White : PlayerColor.Black
            state.status.gameId = action.payload.gameId
            state.status.thisPlayer = { id: action.payload.guestId, name: action.payload.guestName, token: action.payload.guestToken, color: guestColor, role: Role.Guest }
            state.status.opponent = { id: action.payload.hostId, name: action.payload.hostName, token: action.payload.hostToken, color: action.payload.hostColorId, role: Role.Host }
        });

        builder.addCase(getBoard.fulfilled, (state, action: PayloadAction<IGetBoardResponseDTO>) => {
            var figures = action.payload.figures;
            state.board.activeFigure = undefined;
            state.board.destinationSquare = undefined;
            state.board.isValidMove = undefined;
            state.board.figures = figures
        });
        builder.addCase(executeMove.fulfilled, (state, action) => {
            state.board.activeFigure = undefined
            state.board.destinationSquare = undefined
            state.board.isValidMove = undefined
            state.board.move = undefined
            state.board.pionPromotion = undefined
            state.status.currentPlayerTurn = state.status.currentPlayerTurn !== PlayerColor.White ? PlayerColor.White : PlayerColor.Black
        });
        builder.addCase(executeMove.rejected, (state, action) => {


        });
        builder.addCase(saveMove.fulfilled, (state, action) => {

        });
        builder.addCase(saveMove.rejected, (state, action) => {

        });
    }
})

export const { click, release, pionPromotion, updateBoard, updateGuestInfo } = gameSlice.actions

export default gameSlice.reducer