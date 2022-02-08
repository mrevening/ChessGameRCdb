using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class MoveDirection : IMoveDirection
    {
        public abstract IEnumerable<Coordinate> GetCoordinates(IFigure f);
    }
}
