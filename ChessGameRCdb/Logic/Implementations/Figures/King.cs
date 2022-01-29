﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class King : Figure, IUnremovable
    {
        public override FigureType FigureType { get { return FigureType.King; } }
        public override List<IMove> MoveTypes { get => new List<IMove>() { new CrossAllDirection() }; }

        public King(Color player) : base(player) { }
        public King(Color player, Column column, Row row) : base(player, column, row) { }
        public King(Color player, Coordinate position) : base(player, position) { }

        public override bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint)
        {
            return true;
        }
    }
}
