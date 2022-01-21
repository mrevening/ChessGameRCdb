import { Modal, ModalBody, ModalHeader } from "reactstrap";
import Links from './components/Links'
import CreateGame from './components/CreateGame'
import JoinGame from './components/JoinGame'
import { useAppSelector } from 'state/hooks'

export default function Menu() {
    const showLinks = useAppSelector(store => store.menu.showLinks)
    const showCreateGameView = useAppSelector(store => store.menu.showCreateGameView)
    const showJoinGameView = useAppSelector(store => store.menu.showJoinGameView)

    return (
        <>
            <Modal isOpen={true}>
                <ModalHeader>
                    Chess App!
                </ModalHeader>
                <ModalBody>
                    {
                        <>
                            {showLinks ? <Links /> : null}
                            {showCreateGameView ? <CreateGame /> : null}
                            {showJoinGameView ? <JoinGame /> : null}
                        </>
                    }
                </ModalBody>
            </Modal>
        </>
    );
}