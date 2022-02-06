import { Button } from "reactstrap";
import { useAppDispatch } from "../../state/hooks";
import { showMainMenuView } from '../../slices/MenuSlice'

export default function BackToMainMenuButton() {
    const dispatch = useAppDispatch();

    return (
        <Button onClick={() => dispatch(showMainMenuView()) } color="primary">Back to main menu</Button>
    );
}