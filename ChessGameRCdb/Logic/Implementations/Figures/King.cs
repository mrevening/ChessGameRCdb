using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    internal class King : Figure, IUnremovable
    {
        public override FigureType FigureType { get { return FigureType.King; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public King(Player player) : base(player) { }
        public King(Player player, Column column, Row row) : base(player, column, row) { }
        public King(Player player, Coordinate position) : base(player, position) { }

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
