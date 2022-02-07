import IMoveOption from "../../interfaces/board/IActionMove";
import IFigure from "../../interfaces/board/IFigure";

export interface IExecuteMoveRequestDTO {
    gameId: number
    figures: IFigure[]
    move: IMoveOption
}
