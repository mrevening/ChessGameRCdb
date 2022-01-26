import { useState } from "react";
import { Button, Input } from "reactstrap";
import { useAppDispatch } from "state/hooks";
import { joinGame } from '../MenuSlice'

export default function JoinGame() {
    const dispatch = useAppDispatch();
    const [gameId, setGameId] = useState(0);

    return (
        <>
            <Input type="number" onChange={e => setGameId(Number(e.target.value))} />
            <Button onClick={() => dispatch(joinGame(gameId))} color="primary">Join game</Button>
        </>
    );
}