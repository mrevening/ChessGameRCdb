import { useAppSelector } from "state/hooks";


export default function OpponentPanel() {
    const opponent = useAppSelector(store => store.game.status.opponent)
    return (
        <>
            <div>Opponent: {opponent?.name}</div>
            <div>Role: {opponent?.role}</div>
        </>
    );
}