using ChessGame.Logic.SeedWork;

namespace ChessGame.Logic.Enums
{
    public class GameState : Enumeration
    {
        public static GameState CorrectMove = new GameState(1, nameof(CorrectMove));
        public static GameState InCorrectMove = new GameState(2, nameof(InCorrectMove));
        public static GameState Win = new GameState(3, nameof(Win));
        public static GameState Draw = new GameState(4, nameof(Draw));

        public GameState(int id, string name) : base(id, name) { }
    }
}
