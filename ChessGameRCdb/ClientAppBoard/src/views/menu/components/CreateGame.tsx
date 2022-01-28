import { useState } from "react";
import { Card, Button, ButtonGroup } from "reactstrap";
import { useAppDispatch, useAppSelector } from "state/hooks";
import { PlayerColor } from "../../game/board/enum/PlayerColor";
import { createNewGame } from "../../game/GameSlice";
import { showBoard } from "../MenuSlice";


export default function CreateGame() {
    const dispatch = useAppDispatch();
    const loggedInUser = useAppSelector(store => store.menu.loggedInUser!)
    const [color, setColor] = useState<PlayerColor>(PlayerColor.White);
    return (
        <>
            <Card body className="text-center">
                <ButtonGroup vertical={false}>
                    <Button active={color === PlayerColor.White} color="secondary" outline onClick={() => setColor(PlayerColor.White)}>White</Button>
                    <Button active={color === PlayerColor.Black} color="secondary" outline onClick={() => setColor(PlayerColor.Black)}>Black</Button>
                </ButtonGroup>
            </Card>
            <Button onClick={() => {
                dispatch(showBoard()); dispatch(createNewGame({
                    hostId: loggedInUser.userId, hostName: loggedInUser.username, hostToken: loggedInUser.token, hostColor: color
                }))
            }} color="primary">Start game</Button>
        </>
    );
}