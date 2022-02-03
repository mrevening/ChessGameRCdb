using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Castling : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog = null)
        {
            var isUp = figure.Color.GetDirection() == Direction.Up;


            return allMoveOptions;
        }
    }
}
