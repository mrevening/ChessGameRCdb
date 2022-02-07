import { IExecuteMoveRequestDTO } from "../dto/ExecuteMove/IExecuteMoveRequestDTO";
import { IGetBoardRequestDTO } from "../dto/GetBoard/IGetBoardRequestDTO";
import { IGetBoardResponseDTO } from "../dto/GetBoard/IGetBoardResponseDTO";
import ISaveMoveDTO from "../dto/SaveMove/ISaveMove"

export const BoardAPI = {
    async getBoard(request: IGetBoardRequestDTO) {
        return new Promise<{ response: IGetBoardResponseDTO }>(resolve =>
            fetch(`api/Board/GetBoard?gameId=${request.gameId}`)
            .then(response => response.json() as Promise<IGetBoardResponseDTO>)
            .then((data) => {
                resolve({ response: data })
            })
        );
    },
    async executeMove(request: IExecuteMoveRequestDTO) {
        return new Promise(resolve =>
            fetch(`api/Board/ExecuteMove`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(request),
            })
            .then((data) => {
                resolve({data})
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
                body: JSON.stringify({ GameId: move.gameId, ColumnStart: move.startSquare[0], RowStart: move.startSquare[1], ColumnEnd: move.endSquare[0], RowEnd: move.endSquare[1] }),
            })
            .then(response => response.json() as Promise<boolean>)
            .then((data) => {
                resolve({ saveResult: data })
            })
        );
    }
}