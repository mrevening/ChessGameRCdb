import ISquare from "../../interfaces/board/ISquare";

export default interface ISaveMoveDTO {
    gameId: number,
    startSquare: ISquare,
    endSquare: ISquare
}