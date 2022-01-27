import FigureImage from './FigureImage'
import ActiveStickyFigure from './ActiveStickyFigure'
import { useAppSelector, useAppDispatch } from 'state/hooks'
import { FigureImagePaths } from '../repository/FigureImagePaths'
import { RowLine, } from '../enum/RowLine'
import { ColumnLine } from '../enum/ColumnLine'
import { Color } from '../enum/Color'
import { click, executeMove, release } from '../../GameSlice'

interface TileProps {
    col: ColumnLine
    row: RowLine
}

export default function Tile({ col, row }: TileProps) {
    const dispatch = useAppDispatch();
    const squares = useAppSelector(store => store.game.board.Squares)
    const figures = useAppSelector(store => store.game.board.Figures)
    const activeFigure = useAppSelector(store => store.game.board.activeFigure)

    const square = squares.find(f => f.Column === col && f.Row === row)!
    const figure = figures.find(f => f.Square.Column === square.Column && f.Square.Row === square.Row)
    const isActiveFigure = activeFigure && activeFigure.Square === square
    const figureImg = figure && FigureImagePaths.find(p => p.Color === figure.Color && p.FigureType === figure.Type)?.ImgPath
    const isActiveFigurePossibleMove = activeFigure?.EnableMoves?.some(af => af.Column === square.Column && af.Row === square.Row)

    const colorClass = square.Color === Color.Dark ? 'blackTile' : 'whiteTile'
    const isPossibleMoveClass = isActiveFigurePossibleMove ? 'squareMoveOption' : ''

    const handleMouseDown = (e: React.MouseEvent<HTMLDivElement>) => {
        e.preventDefault();
        dispatch(click({ square }))
    }
    const handleMouseUp = (e: React.MouseEvent<HTMLDivElement>) => {
        e.preventDefault();
        dispatch(release({ square }))
        dispatch(executeMove(square))
    }

    const handleTouchStart = (e: React.TouchEvent<HTMLDivElement>) => {
        dispatch(click({ square }))
    }

    const handleTouchEnd = (e: React.TouchEvent<HTMLDivElement>) => {
        const firstTouchEvent = e.changedTouches[0];
        var element = document.elementsFromPoint(firstTouchEvent.clientX, firstTouchEvent.clientY)
        var tile = element.find(x => x.className.includes('tile'))
        var name = tile?.getAttribute('square')
        var square = squares.find(x => x.Name === name)!
        dispatch(release({ square }))
        dispatch(executeMove(square))
    }

    return (
        <>
            <div
                draggable="false"
                {...{ 'square': square.Name }}
                className={["tile", colorClass, isPossibleMoveClass].join(" ")}
                onMouseDown={(e) => handleMouseDown(e)}
                onMouseUp={(e) => handleMouseUp(e) }
                onTouchStart={(e) => handleTouchStart(e)}
                onTouchEnd={(e) => handleTouchEnd(e) }
            >
                {figure && <FigureImage isActiveFigure={isActiveFigure} figureImg={figureImg} />}
                {figure && isActiveFigure && <ActiveStickyFigure figureImg={figureImg} />}
            </div>
        </>
    );
}