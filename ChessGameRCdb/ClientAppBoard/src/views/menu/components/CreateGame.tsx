import { Button } from "reactstrap";
import { useAppDispatch } from "../../../state/hooks";
import { createNewGame } from '../MenuSlice'

export default function CreateGame() {
    const dispatch = useAppDispatch();

    return (
        <>
            <Button onClick={() => dispatch(createNewGame({})) } color="primary">Start game</Button>
        </>
    );
}