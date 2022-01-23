namespace ChessGame.Logic
{
    public class Player : Enumeration, ISwitchable
    {
        public static Player White = new Player(1, nameof(White));
        public static Player Black = new Player(2, nameof(Black));

        public Player(int id, string name) : base(id, name) { }

        public Player Switch() => Name != White.Name ? White : Black;
    }
}
