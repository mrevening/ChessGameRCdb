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
        public override bool Equals(object obj) => obj != null && Equals(obj as MoveOption);
        public bool Equals(MoveOption moveOption) => Action == moveOption.Action && Log.ToString() == moveOption.Log.ToString();
        public override int GetHashCode() => (Action, Log).GetHashCode();
    }
}
