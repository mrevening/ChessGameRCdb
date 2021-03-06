import ILoggedInRequest from "../dto/LoggedIn/ILoggedInRequest";
import ILoggedInResponse from "../dto/LoggedIn/ILoggedInResponse";

export const menuAPI = {
    async createloggedInEntry(loggedIn: ILoggedInRequest) {
        return new Promise<{ response: ILoggedInResponse }>(resolve =>
            fetch(`api/Menu/LoggedIn`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    id: loggedIn.id,
                    name: loggedIn.name,
                    token: loggedIn.token                    
                }),
            })
                .then(response => response.json() as Promise<ILoggedInResponse>)
                .then((data) => {
                    resolve({ response: data })
                })
        );
    }
}