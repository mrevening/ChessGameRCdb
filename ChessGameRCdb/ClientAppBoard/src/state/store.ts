import { configureStore } from '@reduxjs/toolkit'
import GameReducer from '../views/game/GameSlice';
import BoardReducer from '../views/board/BoardSlice';

const store = configureStore({
    reducer: {
        game: GameReducer,
        board: BoardReducer
    }
})


export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
export default store