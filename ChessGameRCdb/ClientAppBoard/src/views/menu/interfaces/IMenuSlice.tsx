export default interface IMenuSlice {
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