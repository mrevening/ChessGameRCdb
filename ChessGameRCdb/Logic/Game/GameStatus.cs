namespace ChessGame.Logic
{
    public class GameStatus : IGameStatus
    {
        public IBoard BoardStatus { get; private set; }
        public Log Log { get; private set; }
        public GameState GameState { get; private set; }

        public GameStatus(IBoard board, Log log, GameState state)
        {
            BoardStatus = board;
            Log = log;
            GameState = state;
        }
    }
}
