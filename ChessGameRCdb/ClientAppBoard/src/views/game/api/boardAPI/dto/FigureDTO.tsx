import { ActionMoveDTO } from "./ActionMoveDTO";

export interface FigureDTO {
    type: number;
    player: number;
    square: string;
    possibleMoves: Array<ActionMoveDTO>
}