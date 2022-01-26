import { Button, ButtonGroup } from "reactstrap";
import { useAppDispatch } from "../../../state/hooks";
import { showCreateGameView, showJoinGameView, showCreditsView } from '../MenuSlice'
import Logout from '../../authorization/Logout'

export default function Links() {
    const dispatch = useAppDispatch();

    return (
        <ButtonGroup vertical={true}>
            <Button onClick={() => dispatch(showCreateGameView())} color="primary">Create game</Button>
            <Button onClick={() => dispatch(showJoinGameView())} color="primary">Join game</Button>
            <Button onClick={() => dispatch(showCreditsView())} color="primary">Credits</Button>
            <Logout />
            
        </ButtonGroup>
    );
}