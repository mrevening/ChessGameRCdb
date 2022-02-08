﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class EnPassant : Move
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog)
        {
            if (previousLog == null) return allMoveOptions;
            var eF = board.GetFigure(previousLog.EndPoint);
            var isUp = figure.Color.IsUp();
            var col = figure.Coordinate.Column;
            var r = isUp ? Row.Five : Row.Four;
            var eSR = isUp ? Row.Seven : Row.Two;
            var eER = isUp ? Row.Five : Row.Four;
            var eCols =  new List<Column>() { col + 1, col - 1 };
            var i = isUp ? 1 : -1;
            eCols.Remove(null);

            if (eF.FigureType != FigureType.Pawn 
                || figure.Coordinate.Row != r 
                || !eCols.Exists(c => c == eF.Coordinate.Column) 
                || previousLog.StartPoint.Row != eSR
                || previousLog.EndPoint.Row != eER
            ) return allMoveOptions;

            allMoveOptions.Add(new MoveOption(ActionType.EnPassant, new Log(figure.Coordinate, new Coordinate(eF.Coordinate.Column, figure.Coordinate.Row + i)) ));

            return allMoveOptions;
        }
    }
}
