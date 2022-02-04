namespace ChessGame.Logic
{
    public class C : Enumeration
    {
        public static C White   = new C(1, nameof(White));
        public static C Black   = new C(2, nameof(Black));

        public C(int id, string name) : base(id, name) { }
    }
}
