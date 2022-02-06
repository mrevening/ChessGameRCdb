import { FigureType } from "../../repository/enum/FigureType";
import ISquare from "./ISquare";

export default interface ILogSupplement {
    startPoint: ISquare | undefined
    endPoint: ISquare | undefined
    figure: FigureType | undefined;
}