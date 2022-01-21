import { useAppSelector } from 'state/hooks'
import { createGame } from './views/game/GameSlice'
import Game from './views/game/Game'
//import MainMenu from './views/mainMenu/MainMenu'

function App() {
    const showMainMenu = useAppSelector(store => store.game.showMainMenu)
    const showGame = useAppSelector(store => store.game.showGame)

    return (
        <>
            { showGame ? <Game /> : null}
        </>
    );
}

export default App;
