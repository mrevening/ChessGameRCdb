﻿using System.Collections.Generic;

namespace ChessGame.Logic
{
    internal class Pawn : Figure
    {
        public override FigureType FigureType { get { return FigureType.Pawn; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public Pawn(Color player) : base(player) { }
        public Pawn(Color player, Column column, Row row) : base(player, column, row) { }
        public Pawn(Color player, Coordinate position) : base( player, position) { }

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
