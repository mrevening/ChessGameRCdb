import { PlayerColor } from "../../../board/enum/PlayerColor";


export interface ICreateGameResponseDTO {
    gameId: number
    hostId: string
    hostName: string
    hostToken: string
    hostColor: PlayerColor
}