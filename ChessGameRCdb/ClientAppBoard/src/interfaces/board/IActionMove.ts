import { ActionType } from "../../repository/enum/ActionType";
import ILog from "./ILog";

export default interface IMoveOption {
    ActionType: ActionType
    Log: ILog
}