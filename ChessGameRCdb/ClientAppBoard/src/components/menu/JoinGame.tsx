import { useState } from "react";
import { Button, Input } from "reactstrap";
import { useAppDispatch, useAppSelector } from "state/hooks";
import { joinGame } from "../../slices/GameSlice";
import { showGame } from "../../slices/MenuSlice";

export default function JoinGame() {
    const dispatch = useAppDispatch();
    const guestId = useAppSelector(store => store.menu.loggedInUser!.userId);
    const guestName = useAppSelector(store => store.menu.loggedInUser!.username);
    const guestToken = useAppSelector(store => store.menu.loggedInUser!.token);
    const [gameId, setGameId] = useState(0);

    return (
        <>
            <Input type="number" onChange={e => setGameId(Number(e.target.value))} />
            <Button onClick={() => {
                dispatch(showGame()); dispatch(joinGame(
                    { gameId: gameId, guestId: guestId, guestName: guestName, guestToken: guestToken }))
            }} color="primary">Join game</Button>
        </>
    );
}