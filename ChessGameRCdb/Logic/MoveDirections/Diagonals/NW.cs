using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class NW : MoveDirection
    {
        public NW() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f) {
            var isUp = f.Color.IsUp();
            var d = f.Coordinate.GetDiagonal();
            var c = Enumeration.GetAll<X>(isUp).Where(x => x > f.Diagonal.X && Math.Abs(x.Id) + Math.Abs(d.Y.Id) <= 4).Select(x => new Diagonal(x, d.Y, d.C)).Select(x => x.GetCoordinate()).ToList();
            c.RemoveAll(x => x is null);
            return c;
        }   
    }
}
