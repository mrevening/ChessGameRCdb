using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;
using ChessGame.Logic.Interfaces;

namespace ChessGame.Logic.Implementations
{
    internal class MoveWhiteFigure : ActionStrategy
    {
        public override Player CurrentPlayer => Player.White;
        public override Direction Direction => Direction.Up;

        public MoveWhiteFigure(IBoard board) : base(board) { }
    }
}
