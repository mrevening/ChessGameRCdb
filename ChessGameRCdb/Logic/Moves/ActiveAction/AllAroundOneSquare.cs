using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class AllAroundOneSquare : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs = null)
        {
            var possibleCoordinates = GetSimpleAllAroundCoordinates(board, figure);
            allMoveOptions.UnionWith(possibleCoordinates.Select(c =>
            {
                if (board.IsOpponentFigure(c, figure.Color)) return new MoveOption(ActionType.Capture, new Log(figure.Coordinate, c));
                else return new MoveOption(ActionType.Move, new Log(figure.Coordinate, c));
            }));

            return allMoveOptions;
        }
    }
}
