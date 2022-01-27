using System.Collections.Generic;

namespace ChessGame.Logic
{
    internal class Queen : Figure
    {
        public override FigureType FigureType { get { return FigureType.Queen; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public Queen(Color player) : base(player) { }
        public Queen(Color player, Column column, Row row) : base(player, column, row) { }
        public Queen(Color player, Coordinate position) : base(player, position) { }

        public override bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint)
        {
            return true;
        }
        public override IEnumerable<Coordinate> MoveOptions(IBoard board)
        {
            return new List<Coordinate>() { };
        }
    }
}
