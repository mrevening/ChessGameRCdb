import { useAppSelector } from 'state/hooks'
import Game from './views/game/Game'
import MainMenu from './views/menu/Menu'

function App() {
    const showMainMenu = useAppSelector(store => store.menu.showMainMenuView)
    const showGame = useAppSelector(store => store.menu.showGameView)

    return (
        <>
            { showMainMenu ? <MainMenu /> : null}
            { showGame ? <Game /> : null}
        </>
    );
}

export default App;
