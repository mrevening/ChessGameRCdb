import { ActionType } from "../enum/ActionType";
import ILog from "./ILog";

export default interface IMoveOption {
    ActionType: ActionType
    Log: ILog
}