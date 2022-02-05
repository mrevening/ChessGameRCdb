import { BoardDTO } from "./BoardDTO";
import { LogDTO } from "./LogDTO";

export interface SaveLogCalculateAndUpdateBoardRequestDTO {
    gameId: number
    board: BoardDTO
    log: LogDTO
}
