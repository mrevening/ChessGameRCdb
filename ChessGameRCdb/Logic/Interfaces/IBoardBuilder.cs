using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;
using System.Collections.Generic;

namespace ChessGame.Logic.Interfaces
{
    public interface IBoardBuilder
    {
        IBoard CreateBoardFromLogs(IEnumerable<IFigure> figures, IEnumerable<MoveLog> logs);
    }
}
