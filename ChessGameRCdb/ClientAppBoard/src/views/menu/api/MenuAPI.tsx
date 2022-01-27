import ICreateGameRequest from "../interfaces/ICreateGameRequest";
import ICreateGameResponse from "../interfaces/ICreateGameResponse";
import ILoggedInRequest from "../interfaces/ILoggedInRequest";
import ILoggedInResponse from "../interfaces/ILoggedInResponse";

export const menuAPI = {
    async createloggedInEntry(loggedIn: ILoggedInRequest) {
        return new Promise<{ response: ILoggedInResponse }>(resolve =>
            fetch(`api/Menu/LoggedIn`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    tokenId: loggedIn.tokenId,
                    name: loggedIn.name,
                    familyName: loggedIn.familyName,
                    givenName: loggedIn.givenName,
                    email: loggedIn.email,
                    googleId: loggedIn.googleId
                }),
            })
                .then(response => response.json() as Promise<ILoggedInResponse>)
                .then((data) => {
                    resolve({ response: data })
                })
        );
    },
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