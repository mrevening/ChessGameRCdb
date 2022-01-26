export default interface IMenuSlice {
    showLoginView: boolean,
    showLogoutView: boolean,
    showMainMenuView: boolean,
    showLinks: boolean,
    showCreateGameView: boolean
    showJoinGameView: boolean,
    showLoadGameView: boolean,
    showCreditsView: boolean,
    showGameView: boolean,
    isLoggedIn: boolean,
    gameId: number | undefined
}