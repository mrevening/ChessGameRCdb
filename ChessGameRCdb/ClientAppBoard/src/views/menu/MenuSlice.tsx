import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import { menuAPI } from '../../api/menuAPI'

export interface ICreateGame {
}

interface MenuSlice {
    showMainMenuView: boolean,
    showLinks: boolean,
    showCreateGameView: boolean
    showJoinGameView: boolean,
    showLoadGameView: boolean
    showGameView: boolean
}
const initialState: MenuSlice = {
    showMainMenuView: true,
    showLinks: true,
    showCreateGameView: false,
    showJoinGameView: false,
    showLoadGameView: false,
    showGameView: false
}

export const createGame = createAsyncThunk(
    'board/menu',
    async (newGame: ICreateGame, thunkAPI) => {
        await menuAPI.createGame(newGame)
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
        },
        showGameView: (state) => {
            state.showMainMenuView = false
            state.showLinks = false
            state.showCreateGameView = false
            state.showJoinGameView = false
            state.showLoadGameView = false
            state.showGameView = true
        }
    },
    extraReducers: (builder) => {
    }
})

export const { showMainMenuView, showCreateGameView, showJoinGameView, showLoadGameView, showGameView } = menuSlice.actions

export default menuSlice.reducer