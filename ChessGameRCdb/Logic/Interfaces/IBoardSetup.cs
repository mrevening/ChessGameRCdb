using ChessGame.Logic.Enums;
using System.Collections.Generic;

namespace ChessGame.Logic.Interfaces
{
    public interface IBoardSetup
    {
        List<IFigure> Figures { get; }
    }
}
