import ISquare from './ISquare'
import IFigure from './IFigure'
import IMove from './IMove'

export default interface IBoard{
    turn: number,
    squares: Array<ISquare>
    figures: Array<IFigure>,
    actions: Array<IMove>
    enPassant: Array<IFigure>
}
