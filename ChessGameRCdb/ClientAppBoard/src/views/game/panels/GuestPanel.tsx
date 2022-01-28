import { useAppSelector } from "state/hooks";


export default function GuesttPanel() {
    const userName = useAppSelector(store => store.game.status.guest?.name)
    const gameId = useAppSelector(store => store.game.status.gameId)
    return (
        <>
            <div>Guest: {userName}</div>
            <div>GameId: {gameId}</div>
        </>
    );
}