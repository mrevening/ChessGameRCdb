import OpponentPanel from './panels/OpponentPanel';
import Board from './Board';
import CurrentPlayerPanel from './panels/CurrentPlayerPanel';
import { useAppSelector } from '../state/hooks';
import PionPromotion from './promotion/PionPromotion';

export default function Game() {
    const gameId = useAppSelector(store => store.game.status.gameId)

    
    return (
        <>
            {gameId ?
                <>
                    <OpponentPanel />
                    <Board gameId={gameId!} />
                    <CurrentPlayerPanel />

                    <PionPromotion />
                </>
                : null}
        </>
    );
}
