using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OneTileForward : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction)
        {
            var allMoveOptions = new List<MoveOption>();
            if (InitCheck(board, figure)) return allMoveOptions;
            var isUp = direction == Direction.Up;

            return allMoveOptions;
        }
    }
}
