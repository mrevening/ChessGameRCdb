import { Player } from '../enum/Player'
import { FigureType } from '../enum/FigureType'

export default interface IFigureImagePath {
    FigureType: FigureType,
    Color: Player,
    ImgPath: string
}