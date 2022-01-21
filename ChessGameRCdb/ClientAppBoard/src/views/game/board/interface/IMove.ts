import IFigure from '../interface/IFigure'
import ISquare from '../interface/ISquare'
import { FigureAction } from '../enum/FigureAction'

export default interface IMove {
    Figure: IFigure
    Square : ISquare
    Type: FigureAction
    IsExecutable: boolean
}