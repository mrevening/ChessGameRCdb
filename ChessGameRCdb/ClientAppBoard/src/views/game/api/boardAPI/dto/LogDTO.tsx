import { LogSupplementDTO } from "./LogSupplementDTO";

export interface LogDTO {
    startPoint: string
    endPoint: string
    logSupplement: LogSupplementDTO[];
}