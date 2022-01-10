using ChessGame.Logic.Interfaces;
using ChessGame.Logic.SeedWork;

namespace ChessGame.Logic.Enums
{
    public class Direction : Enumeration
    {
        public int Multiplier;

        public static Direction Up = new Direction(1, nameof(Up), 1);
        public static Direction Down = new Direction(2, nameof(Down) , -1);

        public Direction(int id, string name, int multiplier) : base(id, name) { Multiplier = multiplier; }
    }
}
