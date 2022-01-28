import { PlayerColor } from "../../../board/enum/PlayerColor";

export interface ICreateGameRequestDTO {
    hostId: string
    hostName: string
    hostToken: string
    hostColor: PlayerColor
}