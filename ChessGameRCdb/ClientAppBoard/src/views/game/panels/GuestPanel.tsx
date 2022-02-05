import { useAppSelector } from "state/hooks";


export default function GuestPanel() {
    const userName = useAppSelector(store => store.game.status.guest?.name)
    return (
        <>
            <div>Guest: {userName}</div>
        </>
    );
}