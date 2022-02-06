import wbishop from './figures/wbishop.png'
import wking from './figures/wking.png'
import wknight from './figures/wknight.png'
import wpawn from './figures/wpawn.png'
import wqueen from './figures/wqueen.png'
import wrook from './figures/wrook.png'
import bbishop from './figures/bbishop.png'
import bking from './figures/bking.png'
import bknight from './figures/bknight.png'
import bpawn from './figures/bpawn.png'
import bqueen from './figures/bqueen.png'
import brook from './figures/brook.png'
import { FigureType } from './enum/FigureType'
import { PlayerColor } from './enum/PlayerColor'
import IFigureImagePath from '../interfaces/board/IFigureImagePath'

export const FigureImagePaths: Array<IFigureImagePath> = [ 
    { figureType: FigureType.Pawn, color: PlayerColor.White, imgPath: wpawn  },
    { figureType: FigureType.Knight, color: PlayerColor.White, imgPath: wknight  },
    { figureType: FigureType.Bishop, color: PlayerColor.White, imgPath: wbishop  },
    { figureType: FigureType.Rook, color: PlayerColor.White, imgPath: wrook  },
    { figureType: FigureType.Queen, color: PlayerColor.White, imgPath: wqueen  },
    { figureType: FigureType.King, color: PlayerColor.White, imgPath: wking  },
    { figureType: FigureType.Pawn, color: PlayerColor.Black, imgPath: bpawn  },
    { figureType: FigureType.Knight, color: PlayerColor.Black, imgPath: bknight  },
    { figureType: FigureType.Bishop, color: PlayerColor.Black, imgPath: bbishop  },
    { figureType: FigureType.Rook, color: PlayerColor.Black, imgPath: brook  },
    { figureType: FigureType.Queen, color: PlayerColor.Black, imgPath: bqueen  },
    { figureType: FigureType.King, color: PlayerColor.Black, imgPath: bking  },
]