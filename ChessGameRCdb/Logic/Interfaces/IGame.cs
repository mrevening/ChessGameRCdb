using ChessGame.Logic;
using ChessGame.Logic;

namespace ChessGame.Logic
{
    public interface IGame
    {
        IGameStatus PlayersAction(Player player, Coordinate startPoint, Coordinate endPoint);
    }
}
