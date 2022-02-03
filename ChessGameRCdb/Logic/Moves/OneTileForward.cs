using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OneTileForward : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog)
        {
            var isUp = figure.Color.GetDirection() == Direction.Up;
            var i = isUp ? 1 : -1;
            var rf = isUp ? Row.Eight : Row.One;
            var c = new Coordinate(figure.Coordinate.Column.Id, figure.Coordinate.Row.Id + i);
            if (!board.IsEmptyField(c)) return allMoveOptions;
            allMoveOptions.Add(new MoveOption(ActionType.Move, new Log(figure.Coordinate, c)));
            if (figure.Coordinate.Row == rf) allMoveOptions.FirstOrDefault().Action = ActionType.Promotion;

            return allMoveOptions;
        }
    }
}

