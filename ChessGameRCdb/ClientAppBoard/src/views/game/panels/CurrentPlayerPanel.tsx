import { useAppSelector } from "state/hooks";


export default function CurrentPlayerPanel() {
    const userName = useAppSelector(store => store.game.status.thisPlayer?.name)
    return (
        <>
            <div>CurrentPlayer: {userName}</div>
        </>
    );
}