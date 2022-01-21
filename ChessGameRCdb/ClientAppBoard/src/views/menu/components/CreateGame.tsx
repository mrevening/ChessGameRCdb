import { Button } from "reactstrap";
import { useAppDispatch } from "../../../state/hooks";
import { showMainMenuView, showGameView, createNewGame } from '../MenuSlice'

export default function CreateGame() {
    const dispatch = useAppDispatch();

    return (
        <>
            <Button onClick={() => { dispatch(createNewGame()); dispatch(showGameView());  }} color="primary">Start game</Button>
            <Button onClick={() => dispatch(showMainMenuView())} color="primary">Back to main menu</Button>
        </>
    );
}