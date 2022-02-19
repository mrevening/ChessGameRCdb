using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Castle : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs = null)
        {

            var rooks = board.Figures.Where(f => f.Color == figure.Color && f.FigureType == FigureType.Rook);
            //rooks.Select(r => r.)
            return allMoveOptions;
        }
    }
}
