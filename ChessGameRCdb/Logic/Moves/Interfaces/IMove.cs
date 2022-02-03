using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Logic
{
    public interface IMove
    {
        IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog = null);
    }
}
