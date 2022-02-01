using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class MoveOption
    {
        public ActionType Action { get; set; }
        public Log Log { get; private set; }
        public MoveOption(ActionType action, Log log)
        {
            Action = action;
            Log = log;
        }
    }
}
