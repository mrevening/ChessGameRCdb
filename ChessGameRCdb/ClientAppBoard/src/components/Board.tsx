import React, { useEffect } from 'react';
import '../styles/Board.scss'
import { Container } from 'reactstrap'
import { useAppDispatch, useAppSelector } from 'state/hooks'
import { HubConnectionBuilder } from '@microsoft/signalr';
import { getBoard, updateBoard, updateGuestInfo } from '../slices/GameSlice';
import { PlayerColor } from '../repository/enum/PlayerColor';
import { Rows } from '../repository/Rows';
import BoardRow from './board/BoardRow';

interface IBoardProps {
    gameId: number
}

export default function Board({ gameId }: IBoardProps) {
    const dispatch = useAppDispatch();
    useEffect(() => {
        if (gameId) dispatch(getBoard({ gameId }))
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
            { rows.map(row => { return <BoardRow key={row} row={row} /> })}
        </Container>
    )
}
