namespace ChessGame.Logic
{
    public class ActionType : Enumeration
    {
        public static ActionType Move = new ActionType(1, nameof(Move));
        public static ActionType Capture = new ActionType(2, nameof(Capture));
        public static ActionType EnPassant = new ActionType(3, nameof(EnPassant));
        public static ActionType Promotion = new ActionType(4, nameof(Promotion));
        public static ActionType Castle = new ActionType(5, nameof(Castle));
        public static ActionType Check = new ActionType(6, nameof(Check));
        public static ActionType Mate = new ActionType(7, nameof(Mate));
        public static ActionType PromotionWithCapture = new ActionType(8, nameof(PromotionWithCapture));

        public ActionType(int id, string name) : base(id, name) { }
    }
}
