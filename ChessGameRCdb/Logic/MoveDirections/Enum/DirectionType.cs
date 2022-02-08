namespace ChessGame.Logic
{
    public class DirectionType : Enumeration
    {
        public static DirectionType Up = new DirectionType(1, nameof(Up));
        public static DirectionType Down = new DirectionType(2, nameof(Down));
        public static DirectionType Right = new DirectionType(3, nameof(Right));
        public static DirectionType Left = new DirectionType(4, nameof(Left));

        public DirectionType(int id, string name) : base(id, name) { }
    }
}
