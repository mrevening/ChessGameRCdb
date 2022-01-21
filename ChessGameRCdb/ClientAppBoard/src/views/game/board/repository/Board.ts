import IBoard from '../interface/IBoard'
import { Squares } from '../repository/Squares'

export const Board: IBoard = { Turn: 0, Squares: Squares, Figures: [], Actions: [], EnPassant: [] }