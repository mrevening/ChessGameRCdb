import { useAppSelector } from "state/hooks";


export default function OpponentPanel() {
    const opponentId = useAppSelector(store => store.game.status.opponent?.name)
    return (
        <>
            Opponent: {opponentId}
        </>
    );
}