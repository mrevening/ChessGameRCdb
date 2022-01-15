using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Log
    {
        public Log(Coordinate startPoint, Coordinate endPoint, IEnumerable<LogComplexMove> logComplexMove)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            LogComplexMove = logComplexMove;
        }
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }
        public IEnumerable<LogComplexMove> LogComplexMove { get; private set; }
    }
}
