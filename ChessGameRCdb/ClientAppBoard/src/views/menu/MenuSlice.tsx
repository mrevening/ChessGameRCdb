import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit'
import { menuAPI } from './api/MenuAPI'
import ICreateGameRequest from './interfaces/ICreateGameRequest'
import IMenuSlice from './interfaces/IMenuSlice'

const initialState: IMenuSlice = {
    showMainMenuView: true,
    showLinks: false,
    showCreateGameView: false,
    showJoinGameView: false,
    showLoadGameView: false,
    showCreditsView: false,
    showGameView: true,
    isLoggedIn: false,
    gameId: 0
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
            state.isLoggedIn = true
            state.showLinks = true
        },
        loggedOut: (state) => {
            state.isLoggedIn = false
            state.showLinks = false
        },
        showMainMenuView: (state) => {
            state.showMainMenuView = true
            state.showLinks = true
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showCreditsView = false
        },
        showCreateGameView: (state) => {
            state.showCreateGameView = true
            state.showLinks = false
        },
        showJoinGameView: (state) => {
            state.showJoinGameView = true
            state.showLinks = false
        },
        showCreditsView: (state) => {
            state.showCreditsView = true
            state.showLinks = false
        },
        joinGame: (state, action: PayloadAction<number>) => {
            state.showMainMenuView = false
            state.showJoinGameView = false
            state.showGameView = true
            state.gameId = action.payload
        },
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

export const { showMainMenuView, showCreateGameView, showJoinGameView, showCreditsView, joinGame, loggedIn, loggedOut } = menuSlice.actions

export default menuSlice.reducer