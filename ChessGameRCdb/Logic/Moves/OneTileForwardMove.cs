using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OneTileForwardMove : Move
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog)
        {
            var isUp = figure.Color.IsUp();
            var i = figure.Color.GetDirectionSign();
            var rf = isUp ? Row.Eight : Row.One;
            var c = new Coordinate(figure.Coordinate.Column.Id, figure.Coordinate.Row.Id + i);
            if (!board.IsEmptyField(c)) return allMoveOptions;
            if (c.Row == rf) allMoveOptions.Add(new MoveOption(ActionType.Promotion, new Log(figure.Coordinate, c)));
            else allMoveOptions.Add(new MoveOption(ActionType.Move, new Log(figure.Coordinate, c)));
            
            return allMoveOptions;
        }
    }
}

