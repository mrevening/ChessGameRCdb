using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class SW : MoveDirection
    {
        public SW() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f)
        {
            var isUp = f.Color.IsUp();
            var d = f.Coordinate.GetDiagonal();
            var c = Enumeration.GetAll<Y>(isUp).Where(y => y > d.Y && Math.Abs(y.Id) + Math.Abs(d.Y.Id) <= 4).Select(y => new Diagonal(d.X, y, d.C)).Select(x => x.GetCoordinate()).ToList();
            c.RemoveAll(x => x is null);
            return c;
        }
    }
}
