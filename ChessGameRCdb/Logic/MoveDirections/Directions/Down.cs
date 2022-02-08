using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Down : MoveDirection
    {
        public Down() : base() { }

        public override IEnumerable<Coordinate> GetCoordinates(IFigure f) => Enumeration.GetAll<Row>(f.Color.IsUp()).Where(row => row < f.Coordinate.Row).Select(r => new Coordinate(f.Coordinate.Column, r)).ToList();

    }
}
