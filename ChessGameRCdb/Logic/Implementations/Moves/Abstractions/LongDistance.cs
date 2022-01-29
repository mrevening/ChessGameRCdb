using ChessGame.Logic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal abstract class LongDistance: Move
    {
        protected void AddLongDistanceActions(List<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            var isLastMoveCapture = false;
            var coordinatesFreeToMoveOrCapture = coordinates.TakeWhile(c =>
            {
                if (isLastMoveCapture) return false;
                var figureInPosition = board.GetFigure(c);
                if (figureInPosition != null && figureInPosition.Color != figure.Color) isLastMoveCapture = true;
                return figureInPosition == null || figureInPosition.Color != figure.Color;
            }
            );
            allMoveOptions.AddRange(coordinatesFreeToMoveOrCapture.Select(c => new MoveOption(c, ActionType.Move)));
            if (isLastMoveCapture) allMoveOptions.Last().AddAction(ActionType.Capture);
        }
    }
}
