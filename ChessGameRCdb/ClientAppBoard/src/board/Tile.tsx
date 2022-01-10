import FigureImage from './FigureImage'
import ActiveStickyFigure from './ActiveStickyFigure'
import { useAppDispatch } from 'hooks'
import { click, release } from './BoardSlice'
import { useAppSelector } from 'hooks'
import { FigureImagePaths } from './repository/FigureImagePaths'
import { RowLine, } from './enum/RowLine'
import { ColumnLine } from './enum/ColumnLine'
import { Color } from './enum/Color'

interface TileProps {
    col: ColumnLine
    row: RowLine
}

export default function Tile( { col, row }: TileProps ){
    const dispatch = useAppDispatch();
    const squares = useAppSelector(store => store.board.Squares)
    const figures = useAppSelector(store => store.board.Figures)
    const activeFigure = useAppSelector(store => store.board.activeFigure)

    const square = squares.find(f => f.Column === col && f.Row === row)!
    const figure = figures.find(f => f.Square.Column === square.Column && f.Square.Row === square.Row)
    const isActiveFigure = activeFigure && activeFigure.Square == square
    const figureImg = figure && FigureImagePaths.find(p => p.Color === figure.Player && p.FigureType === figure.Type)?.ImgPath
    const isActiveFigurePossibleMove = activeFigure?.EnableMoves?.some(af => af.Column === square.Column && af.Row === square.Row)

    const colorClass = square.Color === Color.Dark ? 'blackTile' : 'whiteTile'
    const isPossibleMoveClass = isActiveFigurePossibleMove ? 'squareMoveOption' : ''
    return (
        <>
            <div
                draggable="false"
                className={["tile", colorClass, isPossibleMoveClass].join(" ")}
                onMouseDown={() => dispatch(click({ square }))}
                onMouseUp={() => dispatch(release({ square }))}
                /*onClick={() => dispatch(fetchUserById('123'))}*/
            >
                {figure && <FigureImage isActiveFigure={isActiveFigure} figureImg={figureImg} />}
                {figure && isActiveFigure && <ActiveStickyFigure figureImg={figureImg} />}
            </div>
        </>
    );
}