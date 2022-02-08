using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class AllDirection : ActiveAction
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
