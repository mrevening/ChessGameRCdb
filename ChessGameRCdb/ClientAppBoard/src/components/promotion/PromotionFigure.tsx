import IFigureImagePath from "../../interfaces/board/IFigureImagePath";

interface FigureImageProps {
    figure: IFigureImagePath
}

export default function PromotionFigure({ figure }: FigureImageProps) {
    return <img src={figure?.ImgPath} alt="figure" draggable="false" />
}