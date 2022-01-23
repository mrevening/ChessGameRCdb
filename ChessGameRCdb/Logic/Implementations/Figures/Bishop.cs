﻿using System.Collections.Generic;

namespace ChessGame.Logic
{
    internal class Bishop : Figure
    {
        public override FigureType FigureType { get { return FigureType.Bishop; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public Bishop(Player player) : base(player) { }
        public Bishop(Player player, Column column, Row row) : base(player, column, row) { }
        public Bishop(Player player, Coordinate position) : base(player, position) { }

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
