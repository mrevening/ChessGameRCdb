using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;

namespace ChessGame.Logic
{
    internal class MoveWhiteFigure : ActionStrategy
    {
        public override Player CurrentPlayer => Player.White;
        public override Direction Direction => Direction.Up;

        public MoveWhiteFigure(IBoard board) : base(board) { }
    }
}
