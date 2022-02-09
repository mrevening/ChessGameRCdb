using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Right : MoveDirection
    {
        public Right() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f) => Enumeration.GetAll<Column>().Where(col => col < f.Coordinate.Column).Distinct().Select(c => new Coordinate(c, f.Coordinate.Row)).ToList();
    }
}
