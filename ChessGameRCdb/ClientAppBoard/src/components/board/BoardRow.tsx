import { Row } from 'reactstrap'
import { Columns } from '../../repository/Columns';
import { PlayerColor } from '../../repository/enum/PlayerColor';
import { RowLine } from '../../repository/enum/RowLine';
import { useAppSelector } from '../../state/hooks';
import BoardCol from './BoardCol'

interface BoardRowProps{
    row: RowLine
}

export default function BoardRow({ row }: BoardRowProps) {
    const playerColor = useAppSelector(store => store.game.status.thisPlayer?.color)
    var columns = playerColor === PlayerColor.White ? Columns : Columns.slice().reverse()
    return (
        <Row noGutters={true}>
            { columns.map(col => <BoardCol key={col} row={row} col={col} /> )}
        </Row>
    );
}