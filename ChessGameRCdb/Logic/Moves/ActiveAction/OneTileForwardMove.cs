using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OneTileForwardMove : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs = null)
        {
            var isUp = figure.Color.IsUp();
            var promotedRow = isUp ? Row.Seven : Row.Two;
            if (figure.Coordinate.Row == promotedRow) return allMoveOptions;
            var i = figure.Color.GetDirectionSign();
            var c = new Coordinate(figure.Coordinate.Column.Id, figure.Coordinate.Row.Id + i);
            if (!board.IsEmptyField(c)) return allMoveOptions;
            else allMoveOptions.Add(new MoveOption(ActionType.Move, new Log(figure.Coordinate, c)));
            
            return allMoveOptions;
        }
    }
}

