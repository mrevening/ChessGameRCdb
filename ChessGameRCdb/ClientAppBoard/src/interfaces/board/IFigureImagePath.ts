import { FigureType } from "../../repository/enum/FigureType";
import { PlayerColor } from "../../repository/enum/PlayerColor";

export default interface IFigureImagePath {
    FigureType: FigureType,
    Color: PlayerColor,
    ImgPath: string
}