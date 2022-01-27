import { PlayerColor } from "../board/enum/PlayerColor";

export default interface ICreateGameResponse {
    gameId: number,
    hostId: String
    hostColor: PlayerColor
}