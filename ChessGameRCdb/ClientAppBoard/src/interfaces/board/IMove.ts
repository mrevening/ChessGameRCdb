import { FigureAction } from '../../repository/enum/FigureAction'
import IFigure from './IFigure'
import ISquare from './ISquare'

export default interface IMove {
    Figure: IFigure
    Square : ISquare
    Type: FigureAction
    IsExecutable: boolean
}