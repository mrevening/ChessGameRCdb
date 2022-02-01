namespace ChessGame.Logic
{
    internal class MoveWhiteFigure : ActionStrategy
    {
        public override Color CurrentPlayer => Color.White;
        public override Direction Direction => Direction.Up;

        public MoveWhiteFigure(IBoard board) : base(board) { }
    }
}
