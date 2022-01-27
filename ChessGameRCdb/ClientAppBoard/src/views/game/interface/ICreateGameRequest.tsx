import { PlayerColor } from "../../game/board/enum/PlayerColor";


export default interface ICreateGameRequest {
    hostId: String
    hostColor: PlayerColor
}