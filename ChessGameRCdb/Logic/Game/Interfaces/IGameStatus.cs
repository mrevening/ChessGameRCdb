namespace ChessGame.Logic
{
    public interface IGameStatus
    {
        IBoard BoardStatus { get; }
        GameState GameState { get; }
        Log Log { get;  }
    }
}
