import { Button } from "reactstrap";
import { useAppDispatch } from "../../../state/hooks";
import { showCreateGameView, showJoinGameView  } from '../MenuSlice'

export default function Links() {
    const dispatch = useAppDispatch();

    return (
        <>
            <Button onClick={() => dispatch(showCreateGameView())} color="primary">Create game</Button>
            <Button onClick={() => dispatch(showJoinGameView())} color="primary">Join game</Button>
        </>
    );
}