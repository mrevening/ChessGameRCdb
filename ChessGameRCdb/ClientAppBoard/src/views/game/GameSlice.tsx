import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import { gameAPI } from '../../api/gameAPI'





export interface ICreateGame {
}



interface GameSlice {
    showMainMenu: boolean,
    showGame: boolean
}
const initialState: GameSlice = {
    showMainMenu: false,
    showGame: true
}

export const createGame = createAsyncThunk(
    'board/createGame',
    async (newGame: ICreateGame, thunkAPI) => {
        await gameAPI.createGame(newGame)
    }
)

export const gameSlice = createSlice({
    name: 'game',
    initialState,
    reducers: {
      
    },
    extraReducers: (builder) => {
    }
})

export const { } = gameSlice.actions

export default gameSlice.reducer