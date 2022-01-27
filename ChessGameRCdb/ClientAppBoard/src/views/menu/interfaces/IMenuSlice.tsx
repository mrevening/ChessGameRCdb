export default interface IMenuSlice {
    showMainMenuView: boolean,
    showLinks: boolean,
    showCreateGameView: boolean
    showJoinGameView: boolean,
    showLoadGameView: boolean,
    showCreditsView: boolean,
    showGameView: boolean,
    isLoggedIn: boolean,
    userId: String | undefined
    gameId: number | undefined
}