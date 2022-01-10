import { useEffect } from 'react';
import './Board.scss'
import { Container } from 'reactstrap'
import BoardRow from './BoardRow'
import { useAppDispatch } from 'hooks'
import { Rows } from 'board/repository/Rows'
import { fetchStandardBoard } from './BoardSlice'

export default function Board() {
    const dispatch = useAppDispatch();
    useEffect(() => {
        dispatch(fetchStandardBoard())
    }, []);

    return (
        <Container>
            { Rows.map((row, i) => { return <BoardRow key={row} row={row} /> })}
        </Container >
    )
}
