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
    }
}