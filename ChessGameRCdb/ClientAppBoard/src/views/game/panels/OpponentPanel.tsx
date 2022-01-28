import { useAppSelector } from "state/hooks";


export default function OpponentPanel() {
    const userName = useAppSelector(store => store.game.status.opponent?.name)
    const gameId = useAppSelector(store => store.game.status.gameId)
    return (
        <>
            <div>Opponent: {userName}</div>
            <div>GameId: {gameId}</div>
        </>
    );
}