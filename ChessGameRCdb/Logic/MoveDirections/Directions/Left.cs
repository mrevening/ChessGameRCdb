using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Left : MoveDirection
    {
        public Left() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f) => Enumeration.GetAll<Column>(true).Where(col => col > f.Coordinate.Column).Distinct().Select(c => new Coordinate(c, f.Coordinate.Row)).ToList();
    }
}
