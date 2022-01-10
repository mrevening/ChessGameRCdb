using ChessGame.Logic.Abstractions;
using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;
using ChessGame.Logic.Interfaces;
using System.Collections.Generic;

namespace ChessGame.Logic.Implementations
{
    internal class Pawn : Figure
    {
        public override FigureType FigureType { get { return FigureType.Pawn; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public Pawn(Player player) : base(player) { }
        public Pawn(Player player, Column column, Row row) : base(player, column, row) { }
        public Pawn(Player player, Coordinate position) : base( player, position) { }

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
