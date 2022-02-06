import { Col } from 'reactstrap'
import { ColumnLine } from '../../repository/enum/ColumnLine';
import { RowLine } from '../../repository/enum/RowLine';
import Tile from './Tile'

interface BoardColProps{
    col: ColumnLine
    row: RowLine
}

export default function BoardCol({ row, col }: BoardColProps){
    let i: number = 0
    
    return (
        <Col>
            <Tile key={i++} row={row} col={col} />
        </Col>
    );
}