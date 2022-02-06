import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit'
import { menuAPI } from '../api/MenuAPI'
import ILoggedInRequest from '../dto/LoggedIn/ILoggedInRequest'
import ILoggedInResponse from '../dto/LoggedIn/ILoggedInResponse'
import IMenuSlice from '../interfaces/menu/IMenuSlice'

const initialState: IMenuSlice = {
    showMainMenuView: true,
    showLinks: false,
    showCreateGameView: false,
    showJoinGameView: false,
    showLoadGameView: false,
    showCreditsView: false,
    showGameView: true,
    isLoggedIn: false,
    loggedInUser: undefined
}


export const loggedIn = createAsyncThunk(
    'menu/loggedIn',
    async (request: ILoggedInRequest) => {
        var result = await menuAPI.createloggedInEntry(request)
        result.response.id = request.id
        result.response.name = request.name
        result.response.token = request.token
        return result.response
    }
)

export const menuSlice = createSlice({
    name: 'menu',
    initialState,
    reducers: {
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
        showBoard: (state) => {
            state.showMainMenuView = false
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = true
        },
        showGame: (state) => {
            state.showMainMenuView = false
            state.showJoinGameView = false
            state.showGameView = true
        },
    },
    extraReducers: (builder) => {
        builder.addCase(loggedIn.fulfilled, (state, action: PayloadAction<ILoggedInResponse>) => {
            state.loggedInUser = {
                userId: action.payload.id,
                username: action.payload.name,
                token: action.payload.token,
            }
            state.isLoggedIn = true
            state.showLinks = true
        });
    }
})

export const { showMainMenuView, showCreateGameView, showJoinGameView, showCreditsView, showGame, showBoard, loggedOut } = menuSlice.actions

export default menuSlice.reducer