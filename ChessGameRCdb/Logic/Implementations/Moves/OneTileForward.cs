﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OneTileForward : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction)
        {
            var allMoveOptions = new List<MoveOption>();
            if (InitCheck(board, figure)) return allMoveOptions;
            var isUp = direction == Direction.Up;
            var i = isUp ? 1 : -1;
            var rf = isUp ? Row.Eight : Row.One;
            var c = new Coordinate(figure.Coordinate.Column.Id, figure.Coordinate.Row.Id + i);
            if (!board.IsEmptyField(c)) return allMoveOptions;
            allMoveOptions.Add(new MoveOption(c, ActionType.Move));
            if (figure.Coordinate.Row == rf) allMoveOptions.FirstOrDefault().AddAction(ActionType.Promotion);

            return allMoveOptions;
        }
    }
}

