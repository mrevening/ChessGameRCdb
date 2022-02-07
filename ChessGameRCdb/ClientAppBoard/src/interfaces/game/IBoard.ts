import IMoveOption from "../board/IActionMove";
import IFigure from "../board/IFigure";
import IPionPromotion from "../board/IPionPromotion";
import ISquare from "../board/ISquare";

export interface IBoard {
    squares: Array<ISquare>
    figures: Array<IFigure> | undefined
    activeFigure: IFigure | undefined
    isValidMove: boolean | undefined
    destinationSquare: ISquare | undefined
    move: IMoveOption | undefined
    pionPromotion: IPionPromotion | undefined
}

