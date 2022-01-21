import { ColumnLine } from '../enum/ColumnLine'
import { RowLine } from '../enum/RowLine'
import { Color } from '../enum/Color'

export default interface ISquare {
    Id: number
    Name: string
    Row: RowLine
    Column: ColumnLine
    Color: Color
}