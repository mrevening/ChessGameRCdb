using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class AllDirectionDiagonal : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs = null)
        {
            var directions = new List<IMoveDirection>() { new NW(), new SW(), new SE(), new NE() };

            directions.ForEach(d =>
            {
                var c = d.GetCoordinates(figure);
                AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, c);
            });

            return allMoveOptions;
        }
    }
}
