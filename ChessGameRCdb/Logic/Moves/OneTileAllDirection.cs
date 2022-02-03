using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OneTileAllDirection : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Direction direction, Log previousLog)
        {
            var isUp = direction == Direction.Up;

            return allMoveOptions;
        }
    }
}
