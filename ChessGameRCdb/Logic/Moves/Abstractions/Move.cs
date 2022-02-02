using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class Move : IMove
    {
        private List<ActionType> _dangerousAction = new List<ActionType>() { ActionType.Check, ActionType.Mate };
        public abstract IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction, Log previousLog);

        protected void AddLongDistanceWithCaptureActions(List<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            var eK = figure.Color == Color.White ? Figure.BlackKing : Figure.WhiteKing;
            var isLastMoveCapture = false;
            //var isCheckPossibility = false;
            var coordinatesFreeToMoveOrCapture = coordinates.TakeWhile(c =>
            {
                //if (isLastMoveCapture)
                //{
                //    if (isCheckPossibility) return false;
                //    var figureInPositionBehind = board.GetFigure(c);
                //    if (figureInPositionBehind.FigureType == eK.FigureType && figureInPositionBehind.Color == eK.Color)
                //    {
                //        isCheckPossibility = true;

                //    }
                //    return false;
                //}
                var figureInPosition = board.GetFigure(c);
                if (figureInPosition != null && figureInPosition.Color != figure.Color) isLastMoveCapture = true;
                return figureInPosition == null || figureInPosition.Color != figure.Color;
            });
            allMoveOptions.AddRange(coordinatesFreeToMoveOrCapture.Select(c => new MoveOption(ActionType.Move, new Log(figure.Coordinate, c))));
            if (isLastMoveCapture) allMoveOptions.Last().Action = ActionType.Capture;
        }

        protected void AddLongDistanceWithoutCaptureActions(List<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            var coordinatesFreeToMoveOrCapture = coordinates.TakeWhile(c => board.IsEmptyField(c));
            allMoveOptions.AddRange(coordinatesFreeToMoveOrCapture.Select(c => new MoveOption(ActionType.Move, new Log(figure.Coordinate, c))));
        }
        //protected void HandleActionsCheckingKing(List<MoveOption> allMoveOptions, IBoard board)
        //{
        //    var k = board.GetPlayersKing();
        //    var ek = board.GetEnemysKing();
        //    foreach (var action in allMoveOptions)
        //    {
        //        var nextMoveBoard = board.CurrentColor.Switch() == Color.White
        //            ? new MoveWhiteFigure(new Board(board.Figures, board.CurrentColor.Switch(), new List<Log>() { action.Log })).OutputBoard
        //            : new MoveBlackFigure(new Board(board.Figures, board.CurrentColor.Switch(), new List<Log>() { action.Log })).OutputBoard;
        //        if (action.Log.EndPoint == ek.Coordinate) {
        //            action.Action = ActionType.Check;
        //            if (nextMoveBoard.GetPlayersKing().MoveOptions.Count <= 0) action.Action = ActionType.Mate;
        //        }
        //        else 
        //        {
        //            if (nextMoveBoard.Figures.Where(x => x.Color == board.CurrentColor.Switch()).Any(x => x.MoveOptions.Any(x => _dangerousAction.Contains(x.Action))))
        //                allMoveOptions.Remove(action);
        //        }
        //    }
        //}
    }
}
