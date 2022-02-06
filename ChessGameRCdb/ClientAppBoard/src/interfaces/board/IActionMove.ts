import { ActionType } from "../../repository/enum/ActionType";
import ILog from "./ILog";

export default interface IMoveOption {
    actionType: ActionType
    log: ILog
}