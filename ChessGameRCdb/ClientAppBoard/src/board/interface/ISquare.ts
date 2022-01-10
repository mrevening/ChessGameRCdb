import { ColumnLine } from 'board/enum/ColumnLine'
import { RowLine } from 'board/enum/RowLine'
import { Color } from 'board/enum/Color'

export default interface ISquare {
    Id: number
    Name: string
    Row: RowLine
    Column: ColumnLine
    Color: Color
}