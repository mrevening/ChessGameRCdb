using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    internal class Knight : Figure
    {
        public override FigureType FigureType { get { return FigureType.Knight; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public Knight(Player player) : base(player) { }
        public Knight(Player player, Column column, Row row) : base(player, column, row) { }
        public Knight(Player player, Coordinate position) : base(player, position) { }

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
