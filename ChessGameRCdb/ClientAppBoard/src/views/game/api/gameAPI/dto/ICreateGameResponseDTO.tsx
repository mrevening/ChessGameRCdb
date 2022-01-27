import { PlayerColor } from "../../../board/enum/PlayerColor";


export interface ICreateGameResponseDTO {
    gameId: number,
    hostId: string
    hostColor: PlayerColor
}