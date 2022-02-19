using System.Collections.Generic;

namespace ChessGame.Logic
{
    internal class AllDirectionStraight : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog = null)
        {
            var directions = new List<IMoveDirection>() { new Up(), new Down(), new Left(), new Right() };

            directions.ForEach(d =>
            {
                var c = d.GetCoordinates(figure);
                AddLongDistanceWithCaptureActions(allMoveOptions, board, figure, c);
            });

            return allMoveOptions;
        }
    }
}
