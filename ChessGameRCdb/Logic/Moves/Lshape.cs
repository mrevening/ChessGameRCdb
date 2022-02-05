﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class LShape : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog)
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

            allMoveOptions.UnionWith(possibleCoordinates.Select(c =>
            {
                if (board.IsOpponentFigure(c, figure.Color)) return new MoveOption(ActionType.Capture, new Log(figure.Coordinate, c));
                else return new MoveOption(ActionType.Move, new Log(figure.Coordinate, c));
            }));

            return allMoveOptions;
        }
    }
}
