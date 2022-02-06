import { IBoard } from "./IBoard";
import { IStatus } from "./IStatus";

export default interface IGameSlice {
    status: IStatus
    board: IBoard
}