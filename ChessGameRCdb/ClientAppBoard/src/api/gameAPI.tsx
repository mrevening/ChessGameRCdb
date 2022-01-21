import { ICreateGame } from "../views/board/BoardSlice"

export const gameAPI = {
    async createGame(gameArgs: ICreateGame) {
        return new Promise<{ id: number }>(resolve =>
            fetch(`api/Board/CreateGame`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ gameArgs }),
            })
                .then(response => response.json() as Promise<number>)
                .then((data) => {
                    resolve({ id: data })
                })
        );
    }
}