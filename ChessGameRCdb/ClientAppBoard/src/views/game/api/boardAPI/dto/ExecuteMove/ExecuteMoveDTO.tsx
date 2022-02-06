import ISquare from "../../../../board/interface/ISquare";
import { IBoard } from "../../../../interfaces/IBoard";

export interface ExecuteMove {
    gameId: number
    board: IBoard
    destinationSquare: ISquare
}
