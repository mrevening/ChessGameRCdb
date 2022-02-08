using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class DiagonalAllDirection : Move
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog = null)
        {
            var isUp = figure.Color.IsUp();
            var d = figure.Coordinate.GetDiagonal();

            var coordinatesUp = Enumeration.GetAll<X>(isUp).Where(x => x > d.X && Math.Abs(x.Id) + Math.Abs(d.Y.Id) <= 4).Select(x => new Diagonal(x, d.Y, d.C)).Select(x => x.GetCoordinate()).ToList();
            var coordinatesDown = Enumeration.GetAll<X>(isUp).Where(x => x < d.X && Math.Abs(x.Id) + Math.Abs(d.Y.Id) <= 4).Select(x => new Diagonal(x, d.Y, d.C)).Select(x => x.GetCoordinate()).ToList();
            var coordinatesLeft = Enumeration.GetAll<Y>(isUp).Where(y => y > d.Y && Math.Abs(y.Id) + Math.Abs(d.Y.Id) <= 4).Select(y => new Diagonal(d.X, y, d.C)).Select(x => x.GetCoordinate()).ToList();
            var coordinatesRight = Enumeration.GetAll<Y>(isUp).Where(y => y < d.Y && Math.Abs(y.Id) + Math.Abs(d.Y.Id) <= 4).Select(y => new Diagonal(d.X, y, d.C)).Select(x => x.GetCoordinate()).ToList();

            coordinatesUp.RemoveAll(x => x is null);
            coordinatesDown.RemoveAll(x => x is null);
            coordinatesLeft.RemoveAll(y => y is null);
            coordinatesRight.RemoveAll(y => y is null);

            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesUp);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesDown);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesLeft);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesRight);

            AddPossibleCheckActions(board, figure, coordinatesUp);
            AddPossibleCheckActions(board, figure, coordinatesDown);
            AddPossibleCheckActions(board, figure, coordinatesLeft);
            AddPossibleCheckActions(board, figure, coordinatesRight);

            return allMoveOptions;
        }
    }
}
