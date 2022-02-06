import { useAppSelector } from "state/hooks";


export default function CurrentPlayerPanel() {
    const currentPlayer = useAppSelector(store => store.game.status.thisPlayer)!
    const gameId = useAppSelector(store => store.game.status.gameId)
    return (
        <>
            <div>CurrentPlayer: {currentPlayer.name}</div>
            <div>Role: {currentPlayer.role}</div>
            <div>GameId: {gameId}</div>
        </>
    );
}