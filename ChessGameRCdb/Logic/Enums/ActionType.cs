namespace ChessGame.Logic
{
    public class ActionType : Enumeration
    {
        public static ActionType Move = new ActionType(1, nameof(Capture));
        public static ActionType Capture = new ActionType(2, nameof(Capture));
        public static ActionType EnPassant = new ActionType(3, nameof(EnPassant));
        public static ActionType Promotion = new ActionType(4, nameof(Promotion));
        public static ActionType Castle = new ActionType(5, nameof(Castle));
        public static ActionType Check = new ActionType(5, nameof(Check));
        public static ActionType Mate = new ActionType(5, nameof(Mate));

        public ActionType(int id, string name) : base(id, name) { }
    }
}
