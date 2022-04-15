using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Castle : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs)
        {
            var rookColumns = new List<Column>() { Column.A, Column.H };

            foreach(var rookColumn in rookColumns)
            {
                //check if king and rook hasn't moved and are not checked
                var isKingAlreadyMoved = previousLogs.Any(l => l.StartPoint == figure.Coordinate);
                if (isKingAlreadyMoved) break;

                var rook = board.Figures.FirstOrDefault(f => f.Coordinate == new Coordinate(rookColumn, figure.Coordinate.Row));
                if (rook == null || previousLogs.Any(l => l.StartPoint == rook.Coordinate)) continue;

                var transferColumns = (rookColumn == Column.A) ? new List<Column>() { Column.B, Column.C, Column.D } : new List<Column>() { Column.F, Column.G };
                var isTranferFieldsOccupied = transferColumns.Any(c => board.Figures.Any(x => x.Coordinate == new Coordinate(c, figure.Coordinate.Row)));
                if (isTranferFieldsOccupied) continue;

                var newKingColumn = rookColumn == Column.A ? Column.C : Column.G;

                var log = new Log(figure.Coordinate, new Coordinate(newKingColumn, figure.Coordinate.Row));
                log.SetCastle();
                allMoveOptions.Add(new MoveOption(ActionType.Castle, log));
            }
            return allMoveOptions;
        }
    }
}
