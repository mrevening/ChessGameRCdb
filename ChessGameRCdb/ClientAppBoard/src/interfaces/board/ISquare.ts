import { Color } from "../../repository/enum/Color";
import { ColumnLine } from "../../repository/enum/ColumnLine";
import { RowLine } from "../../repository/enum/RowLine";

export default interface ISquare {
    Id: number
    Name: string
    Row: RowLine
    Column: ColumnLine
    Color: Color
}