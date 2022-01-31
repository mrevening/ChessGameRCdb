import { ActionType } from "../../../board/enum/ActionType";
import { LogDTO } from "./LogDTO";

export interface MoveOptionDTO {
    action: number
    log: LogDTO;
}