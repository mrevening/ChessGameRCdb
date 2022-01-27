import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit'
import IGameSlice from './board/interface/IGameSlice'

const initialState: IGameSlice = {
    playerId: undefined,
    gameId: 0
}

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