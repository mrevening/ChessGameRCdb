import { PlayerColor } from "../../repository/enum/PlayerColor";
import { Role } from "../../repository/enum/Role";

export interface IPlayer {
    id: string | undefined
    name: string | undefined
    token: string | undefined
    color: PlayerColor | undefined
    role: Role | undefined
}
