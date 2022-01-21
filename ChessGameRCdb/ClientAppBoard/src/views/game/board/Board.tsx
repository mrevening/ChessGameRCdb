import { useEffect } from 'react';
import './Board.scss'
import { Container } from 'reactstrap'
import BoardRow from './components/BoardRow'
import { useAppDispatch, useAppSelector } from 'state/hooks'
import { Rows } from './repository/Rows'
import { getBoard, updateBoard } from './BoardSlice'
import { HubConnectionBuilder } from '@microsoft/signalr';

interface IBoardProps {
    gameId: number
}

export default function Board({ gameId }: IBoardProps) {
    const dispatch = useAppDispatch();
    useEffect(() => {
        if(gameId) dispatch(getBoard(gameId))
    }, [gameId]);

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl('https://localhost:44380/hubs/move')
            .withAutomaticReconnect()
            .build();

        connection.start()
            .then(result => {
                console.log('Connected!');

                connection.on('ReceiveMove', message => {
                    dispatch(updateBoard(message))
                });
            })
            .catch(e => console.log('Connection failed: ', e));

    }, []);

    return (
        <Container>
            { Rows.map((row, i) => { return <BoardRow key={row} row={row} /> })}
        </Container >
    )
}
