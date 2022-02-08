using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class NE : MoveDirection
    {
        public NE() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f)
        {
            var d = f.Coordinate.GetDiagonal();
            var c = Enumeration.GetAll<X>(false).Where(x => x < f.Diagonal.X && Math.Abs(x.Id) + Math.Abs(d.Y.Id) <= 4).Distinct().Select(x => new Diagonal(x, d.Y, d.C)).Select(x => x.GetCoordinate()).ToList();            
            c.RemoveAll(x => x is null);
            return c;
        }
    }
}
