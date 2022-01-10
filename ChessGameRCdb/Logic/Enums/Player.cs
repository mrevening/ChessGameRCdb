using ChessGame.Logic.Interfaces;
using ChessGame.Logic.SeedWork;

namespace ChessGame.Logic.Enums
{
    public class Player : Enumeration, ISwitchable
    {
        public static Player White = new Player(1, nameof(White));
        public static Player Black = new Player(2, nameof(Black));

        public Player(int id, string name) : base(id, name) { }

        public Player Switch() => Name != White.Name ? White : Black;
    }
}
