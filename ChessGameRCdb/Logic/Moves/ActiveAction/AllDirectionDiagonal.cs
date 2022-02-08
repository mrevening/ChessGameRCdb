using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class AllDirectionDiagonal : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog = null)
        {
            var directions = new List<IMoveDirection>() { new NE(), new NW(), new SE(), new SW() };

            directions.ForEach(d =>
            {
                var c = d.GetCoordinates(figure);
                AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, c);
            });

            return allMoveOptions;
        }
    }
}
