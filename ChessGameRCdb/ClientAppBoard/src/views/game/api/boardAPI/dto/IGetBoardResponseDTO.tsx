export interface IGetBoardResponseDTO {
    figures: FigureDTO[]
}

interface FigureDTO {
    type: number;
    player: number;
    square: string;
    possibleMoves: Array<string>
}