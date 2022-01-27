import { PlayerColor } from "./board/enum/PlayerColor";
import IFigure from "./board/interface/IFigure";
import IPionPromotion from "./board/interface/IPionPromotion";
import ISquare from "./board/interface/ISquare";

export default interface IGameSlice {
    status: IStatus
    board: IBoard
}

interface IStatus {
    playerId: Number | undefined
    gameId: number | undefined
}

interface IBoard {
    activeFigure: IFigure | undefined
    currentPlayerTurn: PlayerColor
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined
    destinationSquare: ISquare | undefined
    isValidMove: boolean | undefined
}