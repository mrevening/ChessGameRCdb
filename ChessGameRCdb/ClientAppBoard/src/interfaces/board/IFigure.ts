import { FigureType } from '../../repository/enum/FigureType';
import { PlayerColor } from '../../repository/enum/PlayerColor';
import IMoveOption from './IActionMove'
import ISquare from './ISquare';

export default interface IFigure {
    Id: number
    Type: FigureType
    Color: PlayerColor,
    Square: ISquare
    EnableMoves: Array<IMoveOption> | undefined
}