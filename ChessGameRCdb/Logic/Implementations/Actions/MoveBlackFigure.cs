using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;

namespace ChessGame.Logic
{
    internal class MoveBlackFigure : ActionStrategy
    {
        public override Player CurrentPlayer => Player.Black;
        public override Direction Direction => Direction.Down;

        public MoveBlackFigure(IBoard board) : base(board) { }
    }
}
