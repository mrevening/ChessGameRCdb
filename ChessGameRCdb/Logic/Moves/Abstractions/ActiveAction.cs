using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class ActiveAction : Move, IActiveAction
    {
        public abstract IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs = null);
    }
}
