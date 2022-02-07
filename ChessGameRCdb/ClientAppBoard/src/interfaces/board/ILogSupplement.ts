import { FigureType } from "../../repository/enum/FigureType";

export default interface ILogSupplement {
    startPoint: string
    endPoint: string
    figure: FigureType | undefined;
}