import { Row } from 'reactstrap'
import BoardCol from './BoardCol'
import { RowLine } from '../enum/RowLine'
import { Columns } from '../repository/Columns'

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