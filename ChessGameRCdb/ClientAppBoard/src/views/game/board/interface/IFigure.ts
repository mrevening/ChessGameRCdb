import { FigureType } from '../enum/FigureType'
import { Player } from '../enum/Player'
import ISquare from '../interface/ISquare'

export default interface IFigure {
    Id: number
    Type: FigureType
    Player: Player,
    Square: ISquare
    EnableMoves: Array<ISquare> | undefined
}