import { useState } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { useAppDispatch, useAppSelector } from "../../state/hooks";
import { createGame } from '../board/BoardSlice'

export default function InitGame() {
    const dispatch = useAppDispatch();
    var pionPromotionObject = useAppSelector(store => store.board.PionPromotion)
    const [blockEnter, setBlockEnter] = useState(true);
    const [color, setColor] = useState(null);
    const [userName, setUserName] = useState(null);

    return (
        <>
            <Modal isOpen={true}>
                <ModalHeader>
                    Welcome!
                </ModalHeader>
                <ModalBody>
                    {

                    }
                </ModalBody>
                <ModalFooter>
                    {/*<Button disabled={blockEnter} onClick={() => dispatch(createGame())} color="primary">JoinGame</Button>*/}
                    {/*<Button disabled={blockEnter} onClick={ () => dispatch(createGame()) } color="primary">Start</Button>*/}
                </ModalFooter>
            </Modal>
        </>
    );
}