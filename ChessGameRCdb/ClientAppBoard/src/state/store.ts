import { configureStore } from '@reduxjs/toolkit'
import MenuReducer from 'views/menu/MenuSlice';
import GameReducer from 'views/game/GameSlice';

const store = configureStore({
    reducer: {
        menu: MenuReducer,
        game: GameReducer
    }
})


export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
export default store