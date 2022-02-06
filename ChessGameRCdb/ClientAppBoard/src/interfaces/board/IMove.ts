import { FigureAction } from '../../repository/enum/FigureAction'
import IFigure from './IFigure'
import ISquare from './ISquare'

export default interface IMove {
    figure: IFigure
    square : ISquare
    type: FigureAction
    isExecutable: boolean
}