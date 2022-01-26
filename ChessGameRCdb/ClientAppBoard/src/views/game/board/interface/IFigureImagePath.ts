import { PlayerColor } from '../enum/PlayerColor'
import { FigureType } from '../enum/FigureType'

export default interface IFigureImagePath {
    FigureType: FigureType,
    Color: PlayerColor,
    ImgPath: string
}