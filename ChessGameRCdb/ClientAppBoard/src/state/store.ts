import { configureStore } from '@reduxjs/toolkit'
import GameSlice from '../slices/GameSlice'
import MenuSlice from '../slices/MenuSlice'

const store = configureStore({
    reducer: {
        menu: MenuSlice,
        game: GameSlice
    }
})


export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
export default store