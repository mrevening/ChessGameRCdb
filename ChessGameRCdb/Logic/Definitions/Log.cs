using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Log
    {
        public Log(int gameId, Coordinate startPoint, Coordinate endPoint, IEnumerable<LogComplexMove> logComplexMove)
        {
            GameId = gameId;
            StartPoint = startPoint;
            EndPoint = endPoint;
            LogComplexMove = logComplexMove;
        }
        public int GameId { get; private set; }
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }
        public IEnumerable<LogComplexMove> LogComplexMove { get; private set; }
    }
}
