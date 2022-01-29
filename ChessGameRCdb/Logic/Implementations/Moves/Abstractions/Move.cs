using System.Collections.Generic;

namespace ChessGame.Logic
{
    public abstract class Move : IMove
    {
        public abstract IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction);
    }
}
