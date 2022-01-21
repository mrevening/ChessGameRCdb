import { useAppSelector } from 'state/hooks'
import Game from './views/game/Game'
import MainMenu from './views/menu/Menu'

function App() {
    const showMainMenuComponent = useAppSelector(store => store.menu.showMainMenuView)
    const showGameComponent = useAppSelector(store => store.menu.showGameView)

    return (
        <>
            { showMainMenuComponent ? <MainMenu /> : null}
            { showGameComponent ? <Game /> : null}
        </>
    );
}

export default App;
