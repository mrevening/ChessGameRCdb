﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class NW : MoveDirection
    {
        public NW() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f) 
        {
            var d = f.Coordinate.GetDiagonal();
            var c = Enumeration.GetAll<Y>().Where(y => y > d.Y && Math.Abs(y.Id) + Math.Abs(d.X.Id) <= 4).Distinct().Select(y => new Diagonal(d.X, y, d.C)).Select(x => x.GetCoordinate()).ToList();
            c.RemoveAll(x => x is null);
            return c;
        }   
    }
}
