import { useAppSelector } from 'state/hooks'
import Game from './Game';
import Menu from './Menu';

function App() {
    const showMainMenuComponent = useAppSelector(store => store.menu.showMainMenuView)
    const showGameComponent = useAppSelector(store => store.menu.showGameView)

    return (
        <>

            { showMainMenuComponent ? <Menu /> : null}
            { showGameComponent ? <Game /> : null}
        </>
    );
}

export default App;
