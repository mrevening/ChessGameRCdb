export default interface IMenuSlice {
    showLoginView: boolean,
    showLogoutView: boolean,
    showMainMenuView: boolean,
    showLinks: boolean,
    showCreateGameView: boolean
    showJoinGameView: boolean,
    showLoadGameView: boolean
    showGameView: boolean,
    gameId: number | undefined
}