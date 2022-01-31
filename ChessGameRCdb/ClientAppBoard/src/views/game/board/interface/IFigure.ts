import { FigureType } from '../enum/FigureType'
import { PlayerColor } from '../enum/PlayerColor'
import ISquare from '../interface/ISquare'
import IMoveOption from './IActionMove'

export default interface IFigure {
    Id: number
    Type: FigureType
    Color: PlayerColor,
    Square: ISquare
    EnableMoves: Array<IMoveOption> | undefined
}