using ChessGame.Logic;
using System.Collections;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    internal class EnPassant : Move
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
