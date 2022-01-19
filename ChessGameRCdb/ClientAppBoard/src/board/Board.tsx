import { useEffect } from 'react';
import './Board.scss'
import { Container } from 'reactstrap'
import BoardRow from './BoardRow'
import { useAppDispatch } from 'hooks'
import { Rows } from 'board/repository/Rows'
import { getBoard, updateBoard } from '../BoardSlice'
import { HubConnectionBuilder } from '@microsoft/signalr';

export default function Board() {
    const dispatch = useAppDispatch();
    useEffect(() => {
        dispatch(getBoard())

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
