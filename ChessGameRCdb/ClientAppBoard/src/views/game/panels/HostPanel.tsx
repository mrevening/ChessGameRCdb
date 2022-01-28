import { useAppSelector } from "state/hooks";


export default function HostPanel() {
    const userName = useAppSelector(store => store.game.status.host?.name)
    const gameId = useAppSelector(store => store.game.status.gameId)
    return (
        <>
            <div>Host: {userName}</div>
            <div>GameId: {gameId}</div>
        </>
    );
}