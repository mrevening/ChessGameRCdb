import { Player } from 'board/enum/Player'
import { FigureType } from 'board/enum/FigureType'

export default interface IFigureImagePath {
    FigureType: FigureType,
    Color: Player,
    ImgPath: string
}