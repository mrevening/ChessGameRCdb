import { PlayerColor } from "../../../board/enum/PlayerColor";

export interface ICreateGameRequestDTO {
    hostId: string
    hostColor: PlayerColor
}