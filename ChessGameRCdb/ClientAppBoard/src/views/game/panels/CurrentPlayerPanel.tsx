import { useAppSelector } from "state/hooks";


export default function CurrentPlayerPanel() {
    const playerId = useAppSelector(store => store.game.status.hostId)
    return (
        <>
            You: {playerId}
        </>
    );
}