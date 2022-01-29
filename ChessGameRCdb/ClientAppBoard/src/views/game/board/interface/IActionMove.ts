import { ActionType } from "../enum/ActionType";
import ISquare from "./ISquare";

export default interface IActionMove {
    Square: ISquare
    ActionType: Array<ActionType> | undefined
}