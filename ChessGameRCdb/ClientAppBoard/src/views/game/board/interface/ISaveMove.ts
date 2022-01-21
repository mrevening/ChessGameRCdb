import ISquare from "./ISquare";

export default interface ISaveMove {
    gameId: number,
    startSquare: ISquare,
    endSquare: ISquare
}