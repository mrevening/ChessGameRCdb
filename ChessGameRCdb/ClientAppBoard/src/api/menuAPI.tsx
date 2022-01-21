import { ICreateGame } from "views/menu/MenuSlice"

export const menuAPI = {
    async createGame(gameArgs: ICreateGame) {
        return new Promise<{ id: number }>(resolve =>
            fetch(`api/Game/CreateGame`, {
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