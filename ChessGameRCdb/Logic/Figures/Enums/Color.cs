namespace ChessGame.Logic
{
    public class Color : Enumeration
    {
        public static Color White = new Color(1, nameof(White));
        public static Color Black = new Color(2, nameof(Black));

        public Color(int id, string name) : base(id, name) { }


        public override bool Equals(object other) => other is Coordinate && Equals(other);
        public bool Equals(Color p) => p.Id == Id;
        public static bool operator ==(Color lhs, Color rhs) => lhs.Equals(rhs);
        public static bool operator !=(Color lhs, Color rhs) => !lhs.Equals(rhs);
        public static Color operator !(Color c) => c != White ? White : Black;
        public override int GetHashCode() => Id;
    }
}
