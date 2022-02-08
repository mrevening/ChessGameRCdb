﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Right : MoveDirection
    {
        public Right() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f) => Enumeration.GetAll<Column>(f.Color.IsUp()).Where(col => col < f.Coordinate.Column).Select(c => new Coordinate(c, f.Coordinate.Row)).ToList();
    }
}
