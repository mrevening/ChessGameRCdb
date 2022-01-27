import { PlayerColor } from "../enum/PlayerColor";
import IFigure from "./IFigure";
import IPionPromotion from "./IPionPromotion";
import ISquare from "./ISquare";

export default interface IBoardSlice {
    activeFigure: IFigure | undefined
    currentPlayerTurn: PlayerColor
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined
    destinationSquare: ISquare | undefined
    isValidMove: boolean | undefined
    playerId: Number | undefined
    gameId: number
}