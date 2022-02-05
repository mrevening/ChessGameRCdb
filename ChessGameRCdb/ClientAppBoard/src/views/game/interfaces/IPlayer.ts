import { PlayerColor } from "../board/enum/PlayerColor";
import { Role } from "../board/enum/Role";

export interface IPlayer {
    id: string | undefined
    name: string | undefined
    token: string | undefined
    color: PlayerColor | undefined
    role: Role | undefined
}
