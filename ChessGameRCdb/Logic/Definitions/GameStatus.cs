using ChessGame.Logic;
using ChessGame.Logic;

namespace ChessGame.Logic
{
    public class GameStatus : IGameStatus
    {
        public IBoard BoardStatus { get; private set; }
        public MoveLog Log { get; private set; }
        public GameState GameState { get; private set; }

        public GameStatus(IBoard board, MoveLog log, GameState state)
        {
            BoardStatus = board;
            Log = log;
            GameState = state;
        }
    }
}
