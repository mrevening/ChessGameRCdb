import { resolve } from "url"
import IFigure from "../board/interface/IFigure"
import ISquare from "../board/interface/ISquare"
import { Squares } from "../board/repository/Squares"
import { ISaveMove } from "../BoardSlice"
import { FigureDTO } from "./dto/figureDTO"

export const boardAPI = {
    async fetchStandardBoard() {
        return new Promise<{ figures: Array<IFigure> }>(resolve =>
            fetch(`api/Board/GetCurrentGameStatus?gid=1`)
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
        console.log(move)
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