import { Col } from 'reactstrap'
import Tile from './Tile'
import { ColumnLine,} from '../enum/ColumnLine'
import { RowLine } from '../enum/RowLine'

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