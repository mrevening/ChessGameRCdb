import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit'
import { menuAPI } from './api/MenuAPI'
import ICreateGameRequest from './interfaces/ICreateGameRequest'
import IMenuSlice from './interfaces/IMenuSlice'

const initialState: IMenuSlice = {
    showMainMenuView: false,
    showLoginView: false,
    showLogoutView: false,
    showLinks: false,
    showCreateGameView: false,
    showJoinGameView: false,
    showLoadGameView: false,
    showGameView: true,
    gameId: 45
}

export const createNewGame = createAsyncThunk(
    'menu/createNewGame',
    async (request: ICreateGameRequest, thunkAPI) => {
        var result = await menuAPI.createNewGame({} as ICreateGameRequest)
        return result
    }
)

export const menuSlice = createSlice({
    name: 'menu',
    initialState,
    reducers: {
        loggedIn: (state) => {
            state.showMainMenuView = true
            state.showLoginView = false
            state.showLogoutView = true
            state.showLinks = true
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = false
        },
        loggedOut: (state) => {
            state.showLoginView = true
            state.showLogoutView = false
            state.showMainMenuView = true
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = false
        },
        showMainMenuView: (state) => {
            state.showMainMenuView = true
            state.showLoginView = false
            state.showLogoutView = true
            state.showLinks = true
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = false
        },
        showCreateGameView: (state) => {
            state.showLoginView = false
            state.showLogoutView = true
            state.showMainMenuView = true
            state.showLinks = false
            state.showCreateGameView = true
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = false
        },
        showJoinGameView: (state) => {
            state.showMainMenuView = true
            state.showLoginView = false
            state.showLogoutView = true
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = true
            state.showLoadGameView = false
            state.showGameView = false
        },
        joinGame: (state, action: PayloadAction<number>) => {
            state.showMainMenuView = false
            state.showLoginView = false
            state.showLogoutView = true
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = true
            state.gameId = action.payload
        },
    },
    extraReducers: (builder) => {
        builder.addCase(createNewGame.fulfilled, (state, action) => {
            state.showMainMenuView = false
            state.showLoginView = false
            state.showLogoutView = true
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = true
            state.gameId = action.payload.response.gameId
        });
    }
})

export const { showMainMenuView, showCreateGameView, showJoinGameView, joinGame, loggedIn, loggedOut } = menuSlice.actions

export default menuSlice.reducer