import { Row } from 'reactstrap'
import BoardCol from './BoardCol'
import { RowLine } from 'board/enum/RowLine'
import { Columns } from 'board/repository/Columns'

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