import { Type } from "typescript";
import { PlayerColor } from "../repository/enum/PlayerColor";
import { MoveOptionDTO } from "./MoveOptionDTO";

export interface FigureDTO {
    type: Type;
    color: PlayerColor;
    square: string;
    possibleMoves: Array<MoveOptionDTO>
}