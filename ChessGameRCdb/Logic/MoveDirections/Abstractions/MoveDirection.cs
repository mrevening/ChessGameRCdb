using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class MoveDirection : IMoveDirection
    {
        public static MoveDirection Up = new Up();
        public abstract IEnumerable<Coordinate> GetCoordinates(IFigure f);
    }
}
