import IFigure from "../board/interface/IFigure";
import IPionPromotion from "../board/interface/IPionPromotion";
import ISquare from "../board/interface/ISquare";

export interface IBoard {
    activeFigure: IFigure | undefined
    Squares: Array<ISquare>
    Figures: Array<IFigure>
    PionPromotion: IPionPromotion | undefined
    destinationSquare: ISquare | undefined
    isValidMove: boolean | undefined
}

