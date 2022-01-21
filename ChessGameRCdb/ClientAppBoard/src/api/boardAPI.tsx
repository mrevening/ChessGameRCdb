import IFigure from "../views/board/interface/IFigure"
import ISquare from "../views/board/interface/ISquare"
import { Squares } from "../views/board/repository/Squares"
import { ISaveMove } from "../views/board/BoardSlice"
import { FigureDTO } from "./dto/figureDTO"

export const boardAPI = {
    async getBoard() {
        return new Promise<{ figures: Array<IFigure> }>(resolve =>
            fetch(`api/Board/GetBoard?gid=1`)
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