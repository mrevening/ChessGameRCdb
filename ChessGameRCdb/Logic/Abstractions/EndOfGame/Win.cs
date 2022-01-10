using ChessGame.Logic.Enums;
using ChessGame.Logic.Implementations;
using ChessGame.Logic.Interfaces;

namespace ChessGame.Logic.Abstractions
{
    public abstract class Win : EndOfGame
    {
        public override GameState Type => GameState.Win;

        //public static Checkmate Checkmate = new Checkmate(1, nameof(Checkmate));
        //public static EndOfGame Forfeit = new EndOfGame(1, nameof(Forfeit));
        //public static EndOfGame Resignation = new EndOfGame(1, nameof(Resignation));
        //public static EndOfGame WinOfTime = new EndOfGame(1, nameof(WinOfTime));

         public Win(int id, string name): base(id, name) { }
    }
}
