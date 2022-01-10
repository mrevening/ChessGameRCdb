using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;

namespace ChessGame.Logic.Interfaces
{
    public interface IGame
    {
        IGameStatus PlayersAction(Player player, Coordinate startPoint, Coordinate endPoint);
    }
}
