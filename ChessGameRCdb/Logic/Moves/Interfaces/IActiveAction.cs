using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IActiveAction
    {
        IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs = null);
    }
}
