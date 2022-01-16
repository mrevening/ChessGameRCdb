import IFigure from "../board/interface/IFigure"
import ISquare from "../board/interface/ISquare"
import { Squares } from "../board/repository/Squares"
import { FigureDTO } from "./dto/figureDTO"

export const boardAPI = {
    async fetchStandardBoard() {
        return new Promise<{ figures: Array<IFigure> }>(resolve =>
            fetch(`api/Board/GetCurrentGameStatus`).then(response => response.json() as Promise<FigureDTO[]>).then((data) => {
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
    }
}