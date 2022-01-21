import IFigure from "views/game/board/interface/IFigure"
import ISquare from "views/game/board/interface/ISquare"
import { Squares } from "views/game/board/repository/Squares"
import { ISaveMove } from "views/game/board/BoardSlice"
import { FigureDTO } from "../../../api/dto/FigureDTO"

export const BoardAPI = {
    async getBoard(gameId: number) {
        return new Promise<{ figures: Array<IFigure> }>(resolve =>
            fetch(`api/Board/GetBoard?gid=${gameId}`)
                .then(response => response.json() as Promise<FigureDTO[]>)
                .then((data) => {
                var result = data.map((figure, i) => ({
                    Id: i,
                    Player: figure.player,
                    Type: figure.type,
                    Square: Squares.find(square => square.Name === figure.square) as ISquare,
                    EnableMoves: figure.possibleMoves?.map(eM => Squares.find(square => square.Name === eM) as ISquare)
                } as IFigure))
                resolve({ figures: result })
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
                body: JSON.stringify({ GameId: 1, ColumnStart: move.startSquare.Column, RowStart: move.startSquare.Row, ColumnEnd: move.endSquare.Column, RowEnd: move.endSquare.Row }),
            })
            .then(response => response.json() as Promise<boolean>)
            .then((data) => {
                resolve({ saveResult: data })
            })
        );
    }
}