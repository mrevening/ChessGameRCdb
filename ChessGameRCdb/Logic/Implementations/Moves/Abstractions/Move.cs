﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class Move : IMove
    {
        public abstract IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction);

        protected bool InitCheck(IBoard board, IFigure figure)
        {
            return board.IsEnemysFigure(board.CurrentPlayerColor, figure.Coordinate);
        }

        protected void AddLongDistanceWithCaptureActions(List<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            var isLastMoveCapture = false;
            var coordinatesFreeToMoveOrCapture = coordinates.TakeWhile(c =>
            {
                if (isLastMoveCapture) return false;
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
        protected void RemoveActionsCheckingKing(List<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            foreach (var action in allMoveOptions)
            {
                //var k = figure
                //if ()
            }
        }
    }
}
