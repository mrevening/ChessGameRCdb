﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Castle : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs = null)
        {

//check if king and rook hasn't moved and are not checked
            var isKingAlreadyMoved = previousLogs.Any(l => l.StartPoint == figure.Coordinate);
            if (isKingAlreadyMoved) return allMoveOptions;
            var rookColumn = figure.Coordinate.Column == Column.D ? Column.A : Column.H;
            var rook = board.Figures.FirstOrDefault(f => f.Coordinate == new Coordinate(rookColumn, figure.Coordinate.Row));
            if (rook == null && previousLogs.Any(l => l.StartPoint == rook.Coordinate)) return allMoveOptions;

            var newKingColumn = figure.Coordinate.Column == Column.D ? Column.C : Column.G;

            var log = new Log(figure.Coordinate, new Coordinate(newKingColumn, figure.Coordinate.Row));
            log.SetCastle();
            allMoveOptions.Add(new MoveOption(ActionType.Castle, log));

            return allMoveOptions;
        }
    }
}
