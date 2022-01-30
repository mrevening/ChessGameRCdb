using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class LShape : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction)
        {
            var allMoveOptions = new List<MoveOption>();
            if (InitCheck(board, figure)) return allMoveOptions;

            var c = figure.Coordinate;

            var upRight = new Coordinate(c.Column.Id + 1, c.Row.Id + 2);
            var upLeft = new Coordinate(c.Column.Id - 1, c.Row.Id + 2);
            var leftUp = new Coordinate(c.Column.Id - 2, c.Row.Id + 1);
            var leftDown = new Coordinate(c.Column.Id - 2, c.Row.Id - 1);
            var downLeft = new Coordinate(c.Column.Id - 1, c.Row.Id - 2);
            var downRight = new Coordinate(c.Column.Id + 1, c.Row.Id - 2);
            var rightDown = new Coordinate(c.Column.Id + 2, c.Row.Id - 1);
            var rightUp = new Coordinate(c.Column.Id + 2, c.Row.Id + 1);

            var possibleCoordinates = new List<Coordinate>() { upRight, upLeft, leftUp, leftDown, downLeft, downRight, rightDown, rightUp };
            possibleCoordinates.RemoveAll(x => x.Column == null || x.Row == null || board.IsPlayersFigure(figure.Color, x));
            allMoveOptions.AddRange(possibleCoordinates.Select(c => {
                if (board.IsEnemysFigure(figure.Color, c)) return new MoveOption(c, new List<ActionType>() { ActionType.Move, ActionType.Capture });
                else return new MoveOption(c, ActionType.Move);
            }));
            return allMoveOptions;
        }
    }
}
