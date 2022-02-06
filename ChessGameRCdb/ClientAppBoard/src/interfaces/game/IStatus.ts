import { PlayerColor } from "../../repository/enum/PlayerColor";
import { IPlayer } from "./IPlayer";

export interface IStatus {
    gameId: number | undefined
    currentPlayerTurn: PlayerColor
    thisPlayer: IPlayer | undefined
    opponent: IPlayer | undefined
}
