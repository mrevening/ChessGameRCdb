﻿using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IBoardBuilder
    {
        IBoard CreateBoardFromLogs(IEnumerable<IFigure> figures, IEnumerable<Log> logs);
    }
}
