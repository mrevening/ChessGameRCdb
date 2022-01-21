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
import { Player } from '../enum/Player'

export const FigureImagePaths: Array<IFigureImagePath> = [ 
    { FigureType: FigureType.Pawn, Color: Player.White, ImgPath: wpawn  },
    { FigureType: FigureType.Knight, Color: Player.White, ImgPath: wknight  },
    { FigureType: FigureType.Bishop, Color: Player.White, ImgPath: wbishop  },
    { FigureType: FigureType.Rook, Color: Player.White, ImgPath: wrook  },
    { FigureType: FigureType.Queen, Color: Player.White, ImgPath: wqueen  },
    { FigureType: FigureType.King, Color: Player.White, ImgPath: wking  },
    { FigureType: FigureType.Pawn, Color: Player.Black, ImgPath: bpawn  },
    { FigureType: FigureType.Knight, Color: Player.Black, ImgPath: bknight  },
    { FigureType: FigureType.Bishop, Color: Player.Black, ImgPath: bbishop  },
    { FigureType: FigureType.Rook, Color: Player.Black, ImgPath: brook  },
    { FigureType: FigureType.Queen, Color: Player.Black, ImgPath: bqueen  },
    { FigureType: FigureType.King, Color: Player.Black, ImgPath: bking  },
]