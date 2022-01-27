import Board from './board/Board'
import PionPromotion from './board/components/promotion/PionPromotion'
import { useAppSelector } from '../../state/hooks';
import OpponentPanel from './panels/OpponentPanel';
import CurrentPlayerPanel from './panels/CurrentPlayerPanel';

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
