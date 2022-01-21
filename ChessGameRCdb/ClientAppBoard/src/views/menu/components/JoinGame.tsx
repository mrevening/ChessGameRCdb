import { Button } from "reactstrap";
import { useAppDispatch, useAppSelector } from "../../../state/hooks";
import { showMainMenuView, createNewGame } from '../MenuSlice'

export default function JoinGame() {
    const dispatch = useAppDispatch();

    return (
        <>
            <Button onClick={() => dispatch(createNewGame({}))} color="primary">Start game</Button>
            <Button onClick={() => dispatch(showMainMenuView())} color="primary">Back to main menu</Button>
        </>
    );
}