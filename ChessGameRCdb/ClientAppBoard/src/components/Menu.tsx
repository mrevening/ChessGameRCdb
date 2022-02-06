import { Modal, ModalBody, ModalHeader, ModalFooter } from "reactstrap";
import { useAppSelector } from 'state/hooks'
import Login from "./authorization/Login";
import BackToMainMenuButton from "./menu/BackToMainMenuButton";
import CreateGame from "./menu/CreateGame";
import Credits from "./menu/Credits";
import JoinGame from "./menu/JoinGame";
import Links from "./menu/Links";


export default function Menu() {
    const isLoggedIn = useAppSelector(store => store.menu.isLoggedIn)
    const showLinks = useAppSelector(store => store.menu.showLinks)
    const showCreateGameView = useAppSelector(store => store.menu.showCreateGameView)
    const showJoinGameView = useAppSelector(store => store.menu.showJoinGameView)
    const showCreditsView = useAppSelector(store => store.menu.showCreditsView)
    const userName = useAppSelector(store => store.menu.loggedInUser?.username)

    return (
        <>
            <Modal isOpen={true} style={{ textAlign: "center" }} scrollable={false} centered={true} size="sm">
                <ModalHeader>
                    <div>JW's Cheessboard!</div>
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

                <ModalFooter>
                    {isLoggedIn ? <div>logged as {userName}</div> : null}
                </ModalFooter>
            </Modal>
        </>
    );
}