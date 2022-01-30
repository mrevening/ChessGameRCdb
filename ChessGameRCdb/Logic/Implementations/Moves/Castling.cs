using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Castling : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction)
        {
            var allMoveOptions = new List<MoveOption>();
            if (InitCheck(board, figure)) return allMoveOptions;

            var isUp = direction == Direction.Up;
            var coordinatesUp = Enumeration.GetAll<Row>(isUp).Where(row => row > figure.Coordinate.Row).Select(r => new Coordinate(figure.Coordinate.Column, r)).Take(2);

            AddLongDistanceWithoutCaptureActions(allMoveOptions, board, figure, coordinatesUp);
            return allMoveOptions;
        }
    }
}
