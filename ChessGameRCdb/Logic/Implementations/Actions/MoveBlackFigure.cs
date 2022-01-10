using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;
using ChessGame.Logic.Interfaces;

namespace ChessGame.Logic.Implementations
{
    internal class MoveBlackFigure : ActionStrategy
    {
        public override Player CurrentPlayer => Player.Black;
        public override Direction Direction => Direction.Down;

        public MoveBlackFigure(IBoard board) : base(board) { }
    }
}
