import { Color } from "../../repository/enum/Color";
import { ColumnLine } from "../../repository/enum/ColumnLine";
import { RowLine } from "../../repository/enum/RowLine";

export default interface ISquare {
    name: string
    row: RowLine
    column: ColumnLine
    color: Color
}