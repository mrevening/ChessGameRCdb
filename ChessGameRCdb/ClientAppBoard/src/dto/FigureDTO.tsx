import { MoveOptionDTO } from "./MoveOptionDTO";

export interface FigureDTO {
    type: number;
    color: number;
    square: string;
    possibleMoves: Array<MoveOptionDTO>
}