import { FigureType } from '../../repository/enum/FigureType';
import { PlayerColor } from '../../repository/enum/PlayerColor';
import IMoveOption from './IActionMove'
import ISquare from './ISquare';

export default interface IFigure {
    type: FigureType
    color: PlayerColor,
    square: ISquare
    enableMoves: Array<IMoveOption> | undefined
}