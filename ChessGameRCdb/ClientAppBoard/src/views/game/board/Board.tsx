import { useEffect } from 'react';
import './Board.scss'
import { Container } from 'reactstrap'
import BoardRow from './components/BoardRow'
import { useAppDispatch, useAppSelector } from 'state/hooks'
import { Rows } from './repository/Rows'
import { getBoard, updateBoard, updateGuestInfo } from '../GameSlice'
import { HubConnectionBuilder } from '@microsoft/signalr';
import { PlayerColor } from './enum/PlayerColor';

interface IBoardProps {
    gameId: number
}

export default function Board({ gameId }: IBoardProps) {
    const dispatch = useAppDispatch();
    useEffect(() => {
        if (gameId) dispatch(getBoard( gameId ))
    }, [dispatch, gameId]);

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl(`${process.env.PUBLIC_URL}/hubs/move`)
            .withAutomaticReconnect()
            .build();

        connection.start()
            .then(result => {
                console.log('Connected!');

                connection.on('UpdateBoard', message => {
                    dispatch(updateBoard(message))
                });
                connection.on('UpdateGuestInfo', message => {
                    dispatch(updateGuestInfo(message))
                });
                connection.invoke("JoinRoom", gameId.toString())
            })
            .catch(e => console.log('Connection failed: ', e));
    }, [dispatch, gameId]);

    const playerColor = useAppSelector(store => store.game.status.thisPlayer?.color)

    var rows = playerColor === PlayerColor.White ? Rows : Rows.slice().reverse()

    return (
        <Container>
            { rows.map((row, i) => { return <BoardRow key={row} row={row} /> })}
        </Container>
    )
}
