import { useState } from "react";
import { Button, Input } from "reactstrap";
import { useAppDispatch, useAppSelector } from "state/hooks";
import { joinGame } from "../../game/GameSlice";
import { showGame } from "../MenuSlice";

export default function JoinGame() {
    const dispatch = useAppDispatch();
    const playerId = useAppSelector(store => store.menu.userId!);
    const [gameId, setGameId] = useState(0);

    return (
        <>
            <Input type="number" onChange={e => setGameId(Number(e.target.value))} />
            <Button onClick={() => { dispatch(showGame()); dispatch(joinGame({ gameId: gameId, guestId: playerId })) }} color="primary">Join game</Button>
        </>
    );
}