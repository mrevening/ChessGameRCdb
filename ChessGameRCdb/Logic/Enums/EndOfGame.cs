using ChessGame.Logic.Interfaces;
using ChessGame.Logic.SeedWork;

namespace ChessGame.Logic.Enums
{
    public class EndOfGame : Enumeration, IEndGameScenario
    {
        public virtual GameState Type { get; }
        public EndOfGame(int id, string name) : base(id, name) { }
        public virtual bool VerifyScenario(IBoard board) { return false; }
    }
}
