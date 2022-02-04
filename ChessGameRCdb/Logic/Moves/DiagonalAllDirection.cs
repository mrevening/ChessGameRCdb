using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class DiagonalAllDirection : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog = null)
        {
            var isUp = figure.Color.IsUp();
            var d = figure.Coordinate.GetDiagonal();

            var coordinatesUp = Enumeration.GetAll<X>(isUp).Where(x => x > d.X).Select(x => new Diagonal(x, d.Y, d.C)).Select(x => x.GetCoordinate());
            var coordinatesDown = Enumeration.GetAll<X>(isUp).Where(x => x < d.X).Select(x => new Diagonal(x, d.Y, d.C)).Select(x => x.GetCoordinate());
            var coordinatesLeft = Enumeration.GetAll<Y>(isUp).Where(y => y > d.Y).Select(y => new Diagonal(d.X, y, d.C)).Select(x => x.GetCoordinate());
            var coordinatesRight = Enumeration.GetAll<Y>(isUp).Where(y => y < d.Y).Select(y => new Diagonal(d.X, y, d.C)).Select(x => x.GetCoordinate());

            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesUp);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesDown);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesLeft);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesRight);

            return allMoveOptions;
        }
    }
}
