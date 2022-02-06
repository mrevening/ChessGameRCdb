import { IGetBoardResponseDTO } from "../dto/GetBoard/IGetBoardResponseDTO";
import ISaveMoveDTO from "../dto/SaveMove/ISaveMove"

export const BoardAPI = {
    async getBoard(gameId: number) {
        return new Promise<{ response: IGetBoardResponseDTO }>(resolve =>
            fetch(`api/Board/GetBoard?gameId=${gameId}`)
            .then(response => response.json() as Promise<IGetBoardResponseDTO>)
            .then((data) => {
                resolve({ response: data })
            })
        );
    },
    async saveMove(move: ISaveMoveDTO) {
        return new Promise<{ saveResult: boolean }>(resolve =>
            fetch(`api/Board/SaveMove`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ GameId: move.gameId, ColumnStart: move.startSquare.Column, RowStart: move.startSquare.Row, ColumnEnd: move.endSquare.Column, RowEnd: move.endSquare.Row }),
            })
            .then(response => response.json() as Promise<boolean>)
            .then((data) => {
                resolve({ saveResult: data })
            })
        );
    }
}