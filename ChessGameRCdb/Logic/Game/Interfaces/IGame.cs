namespace ChessGame.Logic
{
    public interface IGame
    {
        IGameStatus PlayersAction(Color player, Coordinate startPoint, Coordinate endPoint);
    }
}
