import ILoggedInRequest from "../interface/ILoggedInRequest";
import ILoggedInResponse from "../interface/ILoggedInResponse";

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
                    name: loggedIn.name
                }),
            })
                .then(response => response.json() as Promise<ILoggedInResponse>)
                .then((data) => {
                    resolve({ response: data })
                })
        );
    }
}