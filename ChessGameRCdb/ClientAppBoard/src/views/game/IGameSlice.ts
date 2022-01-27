import { PlayerColor } from "./board/enum/PlayerColor";
import IFigure from "./board/interface/IFigure";
import IPionPromotion from "./board/interface/IPionPromotion";
import ISquare from "./board/interface/ISquare";

export default interface IGameSlice {
    status: IStatus
    board: IBoard
}

interface IStatus {
    gameId: number | undefined
    hostId: string | undefined
    guestId: string | undefined
    thisPlayer: IPlayer | undefined
    oponent: IPlayer | undefined
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

interface IPlayer {
    playerId: string | undefined
    playerColor: PlayerColor | undefined
}