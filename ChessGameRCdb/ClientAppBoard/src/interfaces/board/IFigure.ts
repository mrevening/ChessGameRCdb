import { FigureType } from '../../repository/enum/FigureType';
import { PlayerColor } from '../../repository/enum/PlayerColor';
import IMoveOption from './IActionMove'

export default interface IFigure {
    type: FigureType
    color: PlayerColor,
    square: string
    enableMoves: Array<IMoveOption> | undefined
}