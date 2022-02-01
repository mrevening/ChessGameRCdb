using ChessGame.Logic;

namespace ChessGame.Logic
{
    public class Draw : EndOfGame
    {
        public override GameState Type => GameState.Draw;

        //public static Draw Stalemate = new Draw(1, nameof(Stalemate));
        //public static Draw DeadPosition = new Draw(1, nameof(DeadPosition));
        //public static Draw DrawByAgreement = new Draw(1, nameof(DeadPosition));
        //public static Draw ThreefoldRepetition = new Draw(1, nameof(DeadPosition));
        //public static Draw FiftyMoveRule = new Draw(1, nameof(DeadPosition));
        //public static Draw DrawOnTime = new Draw(1, nameof(DeadPosition));

        public Draw(int id, string name) : base(id, name) { }
    }
}
