import FigureImage from './FigureImage'
import ActiveStickyFigure from './ActiveStickyFigure'
import { useAppSelector, useAppDispatch } from 'state/hooks'
import { ColumnLine } from '../../repository/enum/ColumnLine';
import { RowLine } from '../../repository/enum/RowLine';
import { FigureImagePaths } from '../../repository/FigureImagePaths';
import { Color } from '../../repository/enum/Color';
import { click, executeMove, release } from '../../slices/GameSlice';

interface TileProps {
    col: ColumnLine
    row: RowLine
}

export default function Tile({ col, row }: TileProps) {
    const dispatch = useAppDispatch();
    const squares = useAppSelector(store => store.game.board.squares)
    const figures = useAppSelector(store => store.game.board.figures)
    const activeFigure = useAppSelector(store => store.game.board.activeFigure)
    const square = squares.find(f => f.column === col && f.row === row)!
    const figure = figures?.find(f => f.square === square.name)

    const isActiveFigure = activeFigure?.square === square.name
    const figureImg = figure && FigureImagePaths.find(p => p.color === figure.color && p.figureType === figure.type)?.imgPath
    const isActiveFigurePossibleMove = activeFigure?.enableMoves?.some(af => af.log?.end === square.name)

    const colorClass = square.color === Color.Dark ? 'blackTile' : 'whiteTile'
    const isPossibleMoveClass = isActiveFigurePossibleMove ? 'squareMoveOption' : ''

    const handleMouseDown = (e: React.MouseEvent<HTMLDivElement>) => {
        e.preventDefault();
        dispatch(click({ square }))
    }
    const handleMouseUp = (e: React.MouseEvent<HTMLDivElement>) => {
        e.preventDefault();
        dispatch(release({ square }))
        dispatch(executeMove())
    }

    const handleTouchStart = (e: React.TouchEvent<HTMLDivElement>) => {
        dispatch(click({ square }))
    }

    const handleTouchEnd = (e: React.TouchEvent<HTMLDivElement>) => {
        const firstTouchEvent = e.changedTouches[0];
        var element = document.elementsFromPoint(firstTouchEvent.clientX, firstTouchEvent.clientY)
        var tile = element.find(x => x.className.includes('tile'))
        var name = tile?.getAttribute('square')
        var square = squares.find(x => x.name === name)!
        dispatch(release({ square }))
        dispatch(executeMove())
    }

    return (
        <>
            <div
                draggable="false"
                {...{ 'square': square.name }}
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