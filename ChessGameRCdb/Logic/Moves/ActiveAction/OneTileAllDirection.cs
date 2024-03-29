﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OneTileAllDirection : ActiveAction
    {
        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs = null)
        {
            var isUp = figure.Color.IsUp();

            return allMoveOptions;
        }
    }
}
