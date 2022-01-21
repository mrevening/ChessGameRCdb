import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import { menuAPI } from './menuAPI'
import ICreateGameResponse from './interfaces/ICreateGameRequest'
import IMenuSlice from './interfaces/IMenuSlice'

const initialState: IMenuSlice = {
    showMainMenuView: true,
    showLinks: true,
    showCreateGameView: false,
    showJoinGameView: false,
    showLoadGameView: false,
    showGameView: false
}

export const createNewGame = createAsyncThunk(
    'menu/createNewGame',
    async (_, thunkAPI) => {
        return await menuAPI.createNewGame({})
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
        builder.addCase(createNewGame.fulfilled, (state, action: PayloadAction<ICreateGameResponse>) => {

        });
    }
})

export const { showMainMenuView, showCreateGameView, showJoinGameView, showLoadGameView, showGameView } = menuSlice.actions

export default menuSlice.reducer