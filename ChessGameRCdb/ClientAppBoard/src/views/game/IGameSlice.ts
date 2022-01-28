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
    currentPlayerTurn: PlayerColor
    host: IPlayer | undefined
    guest: IPlayer | undefined
    thisPlayer: IPlayer | undefined
    opponent: IPlayer | undefined
}

interface IBoard {
    activeFigure: IFigure | undefined
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined
    destinationSquare: ISquare | undefined
    isValidMove: boolean | undefined
}

interface IPlayer {
    id: string | undefined
    name: string | undefined
    token: string | undefined
    color: PlayerColor | undefined
}
enum ThisPlayer { Host, Guest }