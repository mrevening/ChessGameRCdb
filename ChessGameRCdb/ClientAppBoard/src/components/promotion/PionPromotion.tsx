import { useState } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { useAppDispatch, useAppSelector } from "state/hooks";
import PromotionFigure from './PromotionFigure'
import { FigureType } from "../../repository/enum/FigureType";
import { pionPromotion } from "../../slices/GameSlice";
import { FigureImagePaths } from "../../repository/FigureImagePaths";

export default function PionPromotion() {
    const dispatch = useAppDispatch();
    var pionPromotionObject = useAppSelector(store => store.game.board.pionPromotion)
    const [blockEnter, setBlockEnter] = useState(true);
    const [figureSelected, setFigureSelected] = useState<FigureType>()
    const figures = [FigureType.Knight, FigureType.Bishop, FigureType.Rook, FigureType.Queen]

    return (
        <>
            <Modal isOpen={pionPromotionObject?.showPionPromotionAlert}>
                <ModalHeader>
                    Pion promotion
                </ModalHeader>
                <ModalBody>
                    {
                        figures.map((figure,i) => { return (
                            <Button key={i} outline onClick={() => { setBlockEnter(false); setFigureSelected(figure) }}>
                                <PromotionFigure figure={FigureImagePaths.find(x => x.color === pionPromotionObject?.activePion.color && x.figureType === figure)!} />
                            </Button>
                        )})
                    }
                </ModalBody>
                <ModalFooter>
                    <Button disabled={blockEnter} onClick={() => dispatch(pionPromotion(figureSelected!)) } color="primary">Promote</Button>
                </ModalFooter>
            </Modal>
        </>
    );
}