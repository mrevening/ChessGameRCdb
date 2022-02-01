namespace ChessGame.Logic
{
    public class Color : Enumeration, ISwitchable
    {
        public static Color White = new Color(1, nameof(White));
        public static Color Black = new Color(2, nameof(Black));

        public Color(int id, string name) : base(id, name) { }

        public Color Switch() => Name != White.Name ? White : Black;
    }
}
