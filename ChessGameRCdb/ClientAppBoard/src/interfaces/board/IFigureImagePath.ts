import { FigureType } from "../../repository/enum/FigureType";
import { PlayerColor } from "../../repository/enum/PlayerColor";

export default interface IFigureImagePath {
    figureType: FigureType,
    color: PlayerColor,
    imgPath: string
}