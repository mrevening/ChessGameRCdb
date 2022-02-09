using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Down : MoveDirection
    {
        public Down() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f) => Enumeration.GetAll<Row>(true).Where(row => row < f.Coordinate.Row).Distinct().Select(r => new Coordinate(f.Coordinate.Column, r)).ToList();

    }
}
