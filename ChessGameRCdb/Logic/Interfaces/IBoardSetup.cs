using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IBoardSetup
    {
        List<IFigure> Figures { get; }
    }
}
