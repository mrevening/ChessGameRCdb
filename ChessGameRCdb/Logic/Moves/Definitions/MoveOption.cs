using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class MoveOption
    {
        public ActionType Action { get; set; }
        public Log Log { get; private set; }
        //public IEnumerable<MoveOption> MoveConsequences { get; private set; }
        public MoveOption(ActionType action, Log log)
        {
            Action = action;
            Log = log;
        }

        public override string ToString() => Action.ToString() + Log.StartPoint.ToString() + Log.EndPoint.ToString();

        public override bool Equals(object obj)
        {
            var stu = obj as MoveOption;
            if (stu == null) return false;
            return Action == stu.Action && Log.ToString() == stu.Log.ToString();
        }
        public override int GetHashCode()
        {
            return Action.GetHashCode() * Log.ToString().GetHashCode();
        }
    }
}
