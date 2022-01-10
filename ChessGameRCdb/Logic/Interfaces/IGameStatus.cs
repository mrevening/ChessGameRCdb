using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;

namespace ChessGame.Logic.Interfaces
{
    public interface IGameStatus
    {
        IBoard BoardStatus { get; }
        GameState GameState { get; }
        MoveLog Log { get;  }
    }
}
