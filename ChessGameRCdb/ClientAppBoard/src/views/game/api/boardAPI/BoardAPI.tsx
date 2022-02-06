import ISaveMove from "../../board/interface/ISaveMove"
import { IGetBoardResponseDTO } from "./dto/IGetBoardResponseDTO"
import { SaveLogCalculateAndUpdateBoardRequestDTO } from "./dto/SaveLogCalculateAndUpdateBoardRequest/SaveLogCalculateAndUpdateBoardRequestDTO";

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
    async saveLogCalculateAndUpdateBoard(dto: SaveLogCalculateAndUpdateBoardRequestDTO) {
        return new Promise(resolve =>
            fetch(`api/Board/UpdateBoard`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(dto),
            })
        );
    },
    async saveMove(move: ISaveMove) {
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