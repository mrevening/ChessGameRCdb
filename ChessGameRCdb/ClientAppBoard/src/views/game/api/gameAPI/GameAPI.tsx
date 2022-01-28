import { ICreateGameRequestDTO } from "./dto/ICreateGameRequestDTO";
import { ICreateGameResponseDTO } from "./dto/ICreateGameResponseDTO";
import { IJoinGameRequestDTO } from "./dto/IJoinGameRequestDTO";
import { IJoinGameResponseDTO } from "./dto/IJoinGameResponseDTO";

export const GameAPI = {
    async createNewGame(args: ICreateGameRequestDTO) {
        return new Promise<{ response: ICreateGameResponseDTO }>(resolve =>
            fetch(`api/Game/CreateNewGame`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(args),
            })
            .then(response => response.json() as Promise<ICreateGameResponseDTO>)
            .then((data) => {
                resolve({ response: data })
            })
        );
    },
    async joinGame(args: IJoinGameRequestDTO) {
        return new Promise<{ response: IJoinGameResponseDTO }>(resolve =>
            fetch(`api/Game/JoinGame`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify( args ),
            })
            .then(response => response.json() as Promise<IJoinGameResponseDTO>)
            .then((data) => {
                resolve({ response: data })
            })
        );
    }
}