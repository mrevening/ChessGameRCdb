import { Modal, ModalBody, ModalHeader, ModalFooter } from "reactstrap";
import Links from './components/Links'
import CreateGame from './components/CreateGame'
import JoinGame from './components/JoinGame'
import Credits from './components/Credits'
import BackToMainMenuButton from './components/BackToMainMenuButton'
import { useAppSelector } from 'state/hooks'
import Login from '../authorization/Login'


export default function Menu() {
    const isLoggedIn = useAppSelector(store => store.menu.isLoggedIn)
    const showLinks = useAppSelector(store => store.menu.showLinks)
    const showCreateGameView = useAppSelector(store => store.menu.showCreateGameView)
    const showJoinGameView = useAppSelector(store => store.menu.showJoinGameView)
    const showCreditsView = useAppSelector(store => store.menu.showCreditsView)

    return (
        <>
            <Modal isOpen={true} style={{ textAlign: "center" }}>
                <ModalHeader style={{ textAlign: "center" }}>
                    Jakub's Personal Chessboard!
                </ModalHeader>
                <ModalBody>
                    {
                        !isLoggedIn ? <Login />
                        :showLinks ? <Links />
                        :<>
                            { showCreateGameView ? <CreateGame /> : null }
                            { showJoinGameView ? <JoinGame /> : null}
                            { showCreditsView ? <Credits /> : null}
                         </>
                    }
                    {isLoggedIn && !showLinks ? <BackToMainMenuButton /> : null} 
                </ModalBody>

                <ModalFooter style={{ textAlign: "center" }}>
                    @Copyrigth 2022 mrevening
                </ModalFooter>
            </Modal>
        </>
    );
}