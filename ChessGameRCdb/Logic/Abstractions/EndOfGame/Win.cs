using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;

namespace ChessGame.Logic
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
