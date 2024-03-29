﻿using System;
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
                if (isLastMoveCapture) return false;
                var figureInPosition = board.GetFigure(c);
                if (figureInPosition == null) return true;
                if (figureInPosition.Color != figure.Color)
                {
                    isLastMoveCapture = true;
                    return true;
                }
                else return false;
            });
            allMoveOptions.UnionWith(coordinatesFreeToMoveOrCapture.Select(c => new MoveOption(ActionType.Move, new Log(figure.Coordinate, c))));
            if (isLastMoveCapture) {
                var last = allMoveOptions.Last();
                var capture = new MoveOption(ActionType.Capture, new Log(last.Log.StartPoint, last.Log.EndPoint));
                allMoveOptions.Remove(last);
                allMoveOptions.Add(capture);
            }
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
        protected IEnumerable<Coordinate> GetSimpleDiagonalCoordinates(IBoard board, IFigure figure)
        {
            var c = figure.Coordinate;
            var direction = figure.Color == Color.White ? 1 : -1;
            var hypotheticCoordinates = new List<Tuple<int, int>>()
            {
                Tuple.Create(c.Column.Id + 1, c.Row.Id + direction),
                Tuple.Create(c.Column.Id - 1, c.Row.Id + direction),
            };
            var possibleCoordinates = new List<Coordinate>();
            hypotheticCoordinates.ForEach(x => { if (Column.Validate(x.Item1) && Row.Validate(x.Item2)) possibleCoordinates.Add(new Coordinate(x.Item1, x.Item2)); });
            possibleCoordinates.RemoveAll(x => board.IsPlayersFigure(x, figure.Color));
            return possibleCoordinates;
        }
        protected IEnumerable<Coordinate> GetSimpleAllAroundCoordinates(IBoard board, IFigure figure)
        {
            var c = figure.Coordinate;
            var hypotheticCoordinates = new List<Tuple<int, int>>()
            {
                Tuple.Create(c.Column.Id - 1, c.Row.Id - 1),
                Tuple.Create(c.Column.Id - 1, c.Row.Id),
                Tuple.Create(c.Column.Id - 1, c.Row.Id + 1),
                Tuple.Create(c.Column.Id    , c.Row.Id - 1),
                Tuple.Create(c.Column.Id    , c.Row.Id),
                Tuple.Create(c.Column.Id    , c.Row.Id + 1),
                Tuple.Create(c.Column.Id + 1, c.Row.Id - 1),
                Tuple.Create(c.Column.Id + 1, c.Row.Id),
                Tuple.Create(c.Column.Id + 1, c.Row.Id + 1),
            };
            var possibleCoordinates = new List<Coordinate>();
            hypotheticCoordinates.ForEach(x => { if (Column.Validate(x.Item1) && Row.Validate(x.Item2)) possibleCoordinates.Add(new Coordinate(x.Item1, x.Item2)); });
            possibleCoordinates.RemoveAll(x => board.IsPlayersFigure(x, figure.Color));
            return possibleCoordinates;
        }
    }
}
