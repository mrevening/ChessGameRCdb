using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Logic
{
    public interface IMove
    {
        IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction, Log previousLog);
    }
}
