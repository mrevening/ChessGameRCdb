﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class TwoTilesForward : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Direction direction, Log previousLog)
        {
            var isUp = direction == Direction.Up;
            var initRow = isUp ? Row.Two : Row.Seven;
            if (figure.Coordinate.Row != initRow) return allMoveOptions;

            var coordinatesUp = Enumeration.GetAll<Row>(isUp).Where(row => isUp ? row > figure.Coordinate.Row : row < figure.Coordinate.Row).Select(r => new Coordinate(figure.Coordinate.Column, r)).Take(2);

            AddLongDistanceWithoutCaptureActions(allMoveOptions, board, figure, coordinatesUp);

            return allMoveOptions;
        }
    }
}
