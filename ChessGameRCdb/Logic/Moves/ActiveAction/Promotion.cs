using System.Collections.Generic;

namespace ChessGame.Logic
{
    internal class Promotion : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs)
        {
            var isUp = figure.Color.IsUp();
            var promotedRow = isUp ? Row.Seven : Row.Two;
            var endRow = isUp ? Row.Eight : Row.One;
            if (figure.Coordinate.Row == promotedRow)
                allMoveOptions.Add(new MoveOption(ActionType.Promotion, new Log(figure.Coordinate, new Coordinate(figure.Coordinate.Column, endRow))));
                
            return allMoveOptions;
        }
    }
}
