using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class TwoTilesForwardMove : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog)
        {
            var isUp = figure.Color.IsUp();
            var initRow = isUp ? Row.Two : Row.Seven;
            if (figure.Coordinate.Row != initRow) return allMoveOptions;

            var coordinatesUp = Enumeration.GetAll<Row>(isUp).Where(row => isUp ? row > figure.Coordinate.Row : row < figure.Coordinate.Row).Select(r => new Coordinate(figure.Coordinate.Column, r)).Take(2);

            AddLongDistanceWithoutCaptureActions(allMoveOptions, board, figure, coordinatesUp);

            return allMoveOptions;
        }
    }
}
