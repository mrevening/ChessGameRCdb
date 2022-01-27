import Board from './board/Board'
import PionPromotion from './board/components/promotion/PionPromotion'
import { useAppDispatch, useAppSelector } from '../../state/hooks';
import { useEffect } from 'react';
import { addGameId } from './GameSlice';

export default function Game() {
    const dispatch = useAppDispatch();
    const gameId = useAppSelector(store => store.menu.gameId)
    
    useEffect(() => {
        if(gameId) dispatch(addGameId(gameId!))
    }, [dispatch, gameId]);

    return (
        <>
            {gameId ? <Board gameId={gameId!} /> : null}
            <PionPromotion />
        </>
    );
}
