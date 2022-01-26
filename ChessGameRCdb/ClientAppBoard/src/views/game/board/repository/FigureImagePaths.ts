import wbishop from '../figures/wbishop.png'
import wking from '../figures/wking.png'
import wknight from '../figures/wknight.png'
import wpawn from '../figures/wpawn.png'
import wqueen from '../figures/wqueen.png'
import wrook from '../figures/wrook.png'
import bbishop from '../figures/bbishop.png'
import bking from '../figures/bking.png'
import bknight from '../figures/bknight.png'
import bpawn from '../figures/bpawn.png'
import bqueen from '../figures/bqueen.png'
import brook from '../figures/brook.png'
import IFigureImagePath from '../interface/IFigureImagePath'
import { FigureType } from '../enum/FigureType'
import { PlayerColor } from '../enum/PlayerColor'

export const FigureImagePaths: Array<IFigureImagePath> = [ 
    { FigureType: FigureType.Pawn, Color: PlayerColor.White, ImgPath: wpawn  },
    { FigureType: FigureType.Knight, Color: PlayerColor.White, ImgPath: wknight  },
    { FigureType: FigureType.Bishop, Color: PlayerColor.White, ImgPath: wbishop  },
    { FigureType: FigureType.Rook, Color: PlayerColor.White, ImgPath: wrook  },
    { FigureType: FigureType.Queen, Color: PlayerColor.White, ImgPath: wqueen  },
    { FigureType: FigureType.King, Color: PlayerColor.White, ImgPath: wking  },
    { FigureType: FigureType.Pawn, Color: PlayerColor.Black, ImgPath: bpawn  },
    { FigureType: FigureType.Knight, Color: PlayerColor.Black, ImgPath: bknight  },
    { FigureType: FigureType.Bishop, Color: PlayerColor.Black, ImgPath: bbishop  },
    { FigureType: FigureType.Rook, Color: PlayerColor.Black, ImgPath: brook  },
    { FigureType: FigureType.Queen, Color: PlayerColor.Black, ImgPath: bqueen  },
    { FigureType: FigureType.King, Color: PlayerColor.Black, ImgPath: bking  },
]