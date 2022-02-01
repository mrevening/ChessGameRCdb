namespace ChessGame.Logic
{
    internal class MoveBlackFigure : ActionStrategy
    {
        public override Color CurrentPlayer => Color.Black;
        public override Direction Direction => Direction.Down;

        public MoveBlackFigure(IBoard board) : base(board) { }
    }
}
