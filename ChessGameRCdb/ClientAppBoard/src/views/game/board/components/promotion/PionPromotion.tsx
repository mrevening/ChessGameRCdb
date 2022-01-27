import { useState } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { useAppDispatch, useAppSelector } from "state/hooks";
import { pionPromotion } from '../../BoardSlice'
import PromotionFigure from './PromotionFigure'
import { FigureImagePaths } from "../../repository/FigureImagePaths"
import { FigureType } from "../../enum/FigureType";

export default function PionPromotion() {
    const dispatch = useAppDispatch();
    var pionPromotionObject = useAppSelector(store => store.board.board.PionPromotion)
    const [blockEnter, setBlockEnter] = useState(true);
    const [figureSelected, setFigureSelected] = useState<FigureType>()
    const figures = [FigureType.Knight, FigureType.Bishop, FigureType.Rook, FigureType.Queen]

    return (
        <>
            <Modal isOpen={pionPromotionObject?.ShowPionPromotionAlert}>
                <ModalHeader>
                    Pion promotion
                </ModalHeader>
                <ModalBody>
                    {
                        figures.map((figure,i) => { return (
                            <Button key={i} outline onClick={() => { setBlockEnter(false); setFigureSelected(figure) }}>
                                <PromotionFigure figure={FigureImagePaths.find(x => x.Color === pionPromotionObject?.ActivePion.Player && x.FigureType === figure)!} />
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