import ISquare from './ISquare'
import IFigure from './IFigure'
import IMove from './IMove'

export default interface IBoard{
    Turn: number,
    Squares: Array<ISquare>
    Figures: Array<IFigure>,
    Actions: Array<IMove>
    EnPassant: Array<IFigure>
}
