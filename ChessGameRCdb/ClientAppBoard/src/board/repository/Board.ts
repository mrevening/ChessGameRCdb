import IBoard from 'board/interface/IBoard'
import { Squares } from 'board/repository/Squares'

export const Board: IBoard = { Turn: 0, Squares: Squares, Figures: [], Actions: [], EnPassant: [] }