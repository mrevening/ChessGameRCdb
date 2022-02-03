using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class CrossAllDirection : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Direction direction, Log previousLog = null)
        {
            var isUp = direction == Direction.Up;

            var coordinatesUp = Enumeration.GetAll<Row>(isUp).Where(row => row > figure.Coordinate.Row).Select(r => new Coordinate(figure.Coordinate.Column, r));
            var coordinatesDown = Enumeration.GetAll<Row>(isUp).Where(row => row < figure.Coordinate.Row).Select(r => new Coordinate(figure.Coordinate.Column, r));
            var coordinatesLeft = Enumeration.GetAll<Column>(isUp).Where(col => col > figure.Coordinate.Column).Select(c => new Coordinate(c, figure.Coordinate.Row));
            var coordinatesRight = Enumeration.GetAll<Column>(isUp).Where(col => col < figure.Coordinate.Column).Select(c => new Coordinate(c, figure.Coordinate.Row));

            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesUp);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesDown);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesLeft);
            AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, coordinatesRight);

            return allMoveOptions;
        }
    }
}
