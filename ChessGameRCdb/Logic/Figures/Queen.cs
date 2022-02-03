﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Queen : Figure
    {
        public override FigureType FigureType { get => FigureType.Queen; }
        public override List<IMove> MoveTypes { get => new List<IMove>() { new CrossAllDirection() }; }

        public Queen(Color player) : base(player) { }
        public Queen(Color player, Column column, Row row) : base(player, column, row) { }
        public Queen(Color player, Coordinate position) : base(player, position) { }

    }
}