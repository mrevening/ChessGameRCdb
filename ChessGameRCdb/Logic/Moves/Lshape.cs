using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class LShape : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction, Log previousLog)
        {
            var allMoveOptions = new List<MoveOption>();

            var c = figure.Coordinate;

            var upRight = new Coordinate(c.Column + 1, c.Row + 2);
            var upLeft = new Coordinate(c.Column - 1, c.Row + 2);
            var leftUp = new Coordinate(c.Column - 2, c.Row + 1);
            var leftDown = new Coordinate(c.Column - 2, c.Row - 1);
            var downLeft = new Coordinate(c.Column - 1, c.Row - 2);
            var downRight = new Coordinate(c.Column + 1, c.Row - 2);
            var rightDown = new Coordinate(c.Column + 2, c.Row - 1);
            var rightUp = new Coordinate(c.Column + 2, c.Row + 1);

            var possibleCoordinates = new List<Coordinate>() { upRight, upLeft, leftUp, leftDown, downLeft, downRight, rightDown, rightUp };
            possibleCoordinates.RemoveAll(x => x.Column == null || x.Row == null || board.IsPlayersFigure(x, figure.Color));
            allMoveOptions.AddRange(possibleCoordinates.Select(c => {
                if (board.IsOpponentFigure(c, figure.Color)) return new MoveOption(ActionType.Capture, new Log(figure.Coordinate, c));
                else return new MoveOption(ActionType.Move, new Log(figure.Coordinate, c));
            }));

            return allMoveOptions;
        }
    }
}
