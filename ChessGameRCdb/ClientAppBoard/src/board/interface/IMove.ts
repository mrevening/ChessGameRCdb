import IFigure from 'board/interface/IFigure'
import ISquare from 'board/interface/ISquare'
import { FigureAction } from 'board/enum/FigureAction'

export default interface IMove {
    Figure: IFigure
    Square : ISquare
    Type: FigureAction
    IsExecutable: boolean
}