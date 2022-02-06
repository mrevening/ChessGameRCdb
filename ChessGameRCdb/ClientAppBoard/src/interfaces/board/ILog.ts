import ILogSupplement from "./ILogSupplement";
import ISquare from "./ISquare";

export default interface ILog {
    startPoint: ISquare
    endPoint: ISquare
    logSupplement: ILogSupplement[];
}