using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class Move
    {
        protected void AddLongDistanceWithCaptureActions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            var eK = figure.Color == Color.White ? Figure.BlackKing : Figure.WhiteKing;
            var isLastMoveCapture = false;
            var coordinatesFreeToMoveOrCapture = coordinates.TakeWhile(c =>
            {
                var figureInPosition = board.GetFigure(c);
                if (figureInPosition != null && figureInPosition.Color != figure.Color) isLastMoveCapture = true;
                return figureInPosition == null || figureInPosition.Color != figure.Color;
            });
            allMoveOptions.UnionWith(coordinatesFreeToMoveOrCapture.Select(c => new MoveOption(ActionType.Move, new Log(figure.Coordinate, c))));
            if (isLastMoveCapture) allMoveOptions.Last().Action = ActionType.Capture;
        }

        protected void AddLongDistanceWithoutCaptureActions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            var coordinatesFreeToMoveOrCapture = coordinates.TakeWhile(c => board.IsEmptyField(c)).ToHashSet();
            allMoveOptions.UnionWith(coordinatesFreeToMoveOrCapture.Select(c => new MoveOption(ActionType.Move, new Log(figure.Coordinate, c))));
            allMoveOptions.Distinct(new MoveOptionComparer());
        }

        protected IEnumerable<Coordinate> GetLShapeCoordinates(IBoard board, IFigure figure)
        {
            var c = figure.Coordinate;
            var hypotheticCoordinates = new List<Tuple<int, int>>()
            {
                Tuple.Create(c.Column.Id + 1, c.Row.Id + 2),
                Tuple.Create(c.Column.Id - 1, c.Row.Id + 2),
                Tuple.Create(c.Column.Id - 2, c.Row.Id + 1),
                Tuple.Create(c.Column.Id - 2, c.Row.Id - 1),
                Tuple.Create(c.Column.Id - 1, c.Row.Id - 2),
                Tuple.Create(c.Column.Id + 1, c.Row.Id - 2),
                Tuple.Create(c.Column.Id + 2, c.Row.Id - 1),
                Tuple.Create(c.Column.Id + 2, c.Row.Id + 1)
            };
            var possibleCoordinates = new List<Coordinate>();
            hypotheticCoordinates.ForEach(x => { if (Column.Validate(x.Item1) && Row.Validate(x.Item2)) possibleCoordinates.Add(new Coordinate(x.Item1, x.Item2)); });
            possibleCoordinates.RemoveAll(x => board.IsPlayersFigure(x, figure.Color));
            return possibleCoordinates;
        }
    }
}
