import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'
import { menuAPI } from './MenuAPI'
import ICreateGameRequest from './interfaces/ICreateGameRequest'
import IMenuSlice from './interfaces/IMenuSlice'
import IBoardSlice from '../game/board/interface/IBoardSlice'

const initialState: IMenuSlice = {
    showMainMenuView: true,
    showLinks: true,
    showCreateGameView: false,
    showJoinGameView: false,
    showLoadGameView: false,
    showGameView: false,
    gameId: 0
}

export const createNewGame = createAsyncThunk(
    'menu/createNewGame',
    async (request: ICreateGameRequest, thunkAPI) => {
        //var { board } = thunkAPI.getState() as { board: IBoardSlice }
        var result = await menuAPI.createNewGame({} as ICreateGameRequest)
        //board.gameId = result.response.GameId
        return result
    }
)

export const menuSlice = createSlice({
    name: 'menu',
    initialState,
    reducers: {
        showMainMenuView: (state) => {
            state.showMainMenuView = true
            state.showLinks = true
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = false
        },
        showCreateGameView: (state) => {
            state.showMainMenuView = true
            state.showLinks = false
            state.showCreateGameView = true
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = false
        },
        showJoinGameView: (state) => {
            state.showMainMenuView = true
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = true
            state.showLoadGameView = false
            state.showGameView = false
        },
        showLoadGameView: (state) => {
            state.showMainMenuView = true
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = true
            state.showGameView = false
        }
    },
    extraReducers: (builder) => {
        builder.addCase(createNewGame.fulfilled, (state, action) => {
            state.showMainMenuView = false
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = true
            state.gameId = action.payload.response.gameId
        });
    }
})

export const { showMainMenuView, showCreateGameView, showJoinGameView, showLoadGameView } = menuSlice.actions

export default menuSlice.reducer