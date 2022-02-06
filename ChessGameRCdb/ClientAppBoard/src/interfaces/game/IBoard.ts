import IFigure from "../board/IFigure";
import IPionPromotion from "../board/IPionPromotion";
import ISquare from "../board/ISquare";

export interface IBoard {
    activeFigure: IFigure | undefined
    squares: Array<ISquare>
    figures: Array<IFigure> | undefined
    pionPromotion: IPionPromotion | undefined
    destinationSquare: ISquare | undefined
    isValidMove: boolean | undefined
}

