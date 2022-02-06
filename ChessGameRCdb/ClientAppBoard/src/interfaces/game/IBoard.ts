import IFigure from "../board/IFigure";
import IPionPromotion from "../board/IPionPromotion";
import ISquare from "../board/ISquare";

export interface IBoard {
    activeFigure: IFigure | undefined
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined
    destinationSquare: ISquare | undefined
    isValidMove: boolean | undefined
}

