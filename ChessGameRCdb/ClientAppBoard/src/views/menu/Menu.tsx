import { Modal, ModalBody, ModalHeader, ModalFooter } from "reactstrap";
import Links from './components/Links'
import CreateGame from './components/CreateGame'
import JoinGame from './components/JoinGame'
import { useAppSelector } from 'state/hooks'
import Login from '../authorization/Login'
import Logout from '../authorization/Logout'

export default function Menu() {
    const showLoginComponent = useAppSelector(store => store.menu.showLoginView)
    const showLogoutComponent = useAppSelector(store => store.menu.showLogoutView)
    const showLinks = useAppSelector(store => store.menu.showLinks)
    const showCreateGameView = useAppSelector(store => store.menu.showCreateGameView)
    const showJoinGameView = useAppSelector(store => store.menu.showJoinGameView)

    return (
        <>
            <Modal isOpen={true}>
                <ModalHeader>
                    Chess App!
                    {showLoginComponent ? <Login /> : null}
                    {showLogoutComponent ? <Logout /> : null}
                </ModalHeader>
                <ModalBody>
                    {showLinks ? <Links /> : null}
                </ModalBody>
                <ModalFooter>
                    {showCreateGameView ? <CreateGame /> : null}
                    {showJoinGameView ? <JoinGame /> : null}
                </ModalFooter>
            </Modal>
        </>
    );
}