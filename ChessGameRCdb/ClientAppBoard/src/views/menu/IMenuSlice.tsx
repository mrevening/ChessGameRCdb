export default interface IMenuSlice {
    showMainMenuView: boolean
    showLinks: boolean
    showCreateGameView: boolean
    showJoinGameView: boolean
    showLoadGameView: boolean
    showCreditsView: boolean
    showGameView: boolean
    isLoggedIn: boolean
    loggedInUser: ILoggedInUser | undefined
}

interface ILoggedInUser {
    userId: string
    username: string
    token: string
}