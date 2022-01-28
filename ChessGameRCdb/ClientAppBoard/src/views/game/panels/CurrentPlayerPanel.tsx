import { useAppSelector } from "state/hooks";


export default function CurrentPlayerPanel() {
    const userName = useAppSelector(store => store.game.status.host?.name)
    const gameId = useAppSelector(store => store.game.status.gameId)
    return (
        <>
            <div>CurrentPlayer: {userName}</div>
            <div>GameId: {gameId}</div>
        </>
    );
}