import { Modal, ModalBody, ModalHeader } from "reactstrap";
import Links from './components/Links'
import CreateGame from './components/CreateGame'
import JoinGame from './components/JoinGame'
import LoadGame from './components/LoadGame'
import { useAppSelector } from 'state/hooks'

export default function Menu() {
    const showLinks = useAppSelector(store => store.menu.showLinks)
    const showCreateGameView = useAppSelector(store => store.menu.showCreateGameView)
    const showJoinGameView = useAppSelector(store => store.menu.showJoinGameView)
    const showLoadGameView = useAppSelector(store => store.menu.showLoadGameView)

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
                            {showLoadGameView ? <LoadGame /> : null}
                        </>
                    }
                </ModalBody>
            </Modal>
        </>
    );
}