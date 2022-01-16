import { configureStore } from '@reduxjs/toolkit'
import BoardReducer from 'BoardSlice';
import MoveAnalysisReducer from 'moveAnalysis/MoveAnalysisSlice';


const store = configureStore({
    reducer: {
        board: BoardReducer
    }
})


export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
export default store