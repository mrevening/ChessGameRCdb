import { Row } from 'reactstrap'
import { Columns } from '../../repository/Columns';
import { RowLine } from '../../repository/enum/RowLine';
import BoardCol from './BoardCol'

interface BoardRowProps{
    row: RowLine
}

export default function BoardRow({ row }: BoardRowProps){
    return (
        <Row noGutters={true}>
            { Columns.map((col, i) => <BoardCol key={col} row={row} col={col} /> )}
        </Row>
    );
}