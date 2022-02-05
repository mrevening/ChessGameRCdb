import { useAppSelector } from "state/hooks";


export default function OpponentPanel() {
    const userName = useAppSelector(store => store.game.status.opponent?.name)
    return (
        <>
            <div>Opponent: {userName}</div>
        </>
    );
}