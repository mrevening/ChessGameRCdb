using ChessGame.Logic;
using ChessGame.Logic;

namespace ChessGame.Logic
{
    public interface IGameStatus
    {
        IBoard BoardStatus { get; }
        GameState GameState { get; }
        MoveLog Log { get;  }
    }
}
