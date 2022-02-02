using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Castling : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction, Log previousLog)
        {
            var allMoveOptions = new List<MoveOption>();
            var isUp = direction == Direction.Up;


            return allMoveOptions;
        }
    }
}
