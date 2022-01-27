import ICreateGameRequest from "./interface/ICreateGameRequest";
import ICreateGameResponse from "./interface/ICreateGameResponse";

export const gameAPI = {
    async createNewGame(gameArgs: ICreateGameRequest) {
        return new Promise<{ response: ICreateGameResponse }>(resolve =>
            fetch(`api/Game/CreateNewGame`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ gameArgs }),
            })
                .then(response => response.json() as Promise<ICreateGameResponse>)
                .then((data) => {
                    resolve({ response: data })
                })
        );
    }
}