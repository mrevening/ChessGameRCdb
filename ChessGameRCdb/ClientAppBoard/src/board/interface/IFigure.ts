import { FigureType } from 'board/enum/FigureType'
import { Player } from 'board/enum/Player'
import ISquare from 'board/interface/ISquare'

export default interface IFigure {
    Id: number
    Type: FigureType
    Player: Player,
    Square: ISquare
    EnableMoves: Array<ISquare> | undefined
}