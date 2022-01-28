import Board from './board/Board'
import PionPromotion from './board/components/promotion/PionPromotion'
import { useAppSelector } from '../../state/hooks';
import OpponentPanel from './panels/OpponentPanel';
import CurrentPlayerPanel from './panels/CurrentPlayerPanel';
import GuesttPanel from './panels/GuestPanel';
import HostPanel from './panels/HostPanel';

export default function Game() {
    const gameId = useAppSelector(store => store.game.status.gameId)
    
    return (
        <>
            {gameId ?
                <>
                    <GuesttPanel />
                    <OpponentPanel />
                    <Board gameId={gameId!} />
                    <CurrentPlayerPanel />
                    <HostPanel />

                    <PionPromotion />
                </>
                : null}
        </>
    );
}
