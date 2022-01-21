import Board from '../board/Board'
import PionPromotion from '../board/components/promotion/PionPromotion'
import Chat from '../chat/Chat'

export default function Game() {
    return (
        <>
            <Chat />
            <Board />
            <PionPromotion />
        </>
    );
}
