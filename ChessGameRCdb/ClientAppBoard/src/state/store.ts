import { configureStore } from '@reduxjs/toolkit'
import MenuReducer from '../views/menu/MenuSlice';
import BoardReducer from '../views/board/BoardSlice';

const store = configureStore({
    reducer: {
        menu: MenuReducer,
        board: BoardReducer
    }
})


export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
export default store