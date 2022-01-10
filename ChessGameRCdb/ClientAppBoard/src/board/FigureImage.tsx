interface FigureImageProps {
    isActiveFigure: boolean | undefined,
    figureImg: string | undefined
}

export default function FigureImage({ isActiveFigure, figureImg }: FigureImageProps) {
    return <div className={(isActiveFigure ? 'noselect activeFigure' : 'noselect figureAbleToMove')}><img src={figureImg} alt="figure" draggable="false" /></div>
}