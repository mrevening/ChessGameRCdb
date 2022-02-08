using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public interface IMoveDirection
    {
        IEnumerable<Coordinate> GetCoordinates(IFigure f);
    }
}
