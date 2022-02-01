using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Log
    {
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }
        public List<LogComplexMove> LogComplexMove { get; private set; }
        public Log(Coordinate startPoint, Coordinate endPoint, List<LogComplexMove> logComplexMove = null)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            LogComplexMove = logComplexMove ?? new List<LogComplexMove>();
        }
        public void AddLogComplexMove(LogComplexMove log)
        {
            LogComplexMove.Add(log);
        }
    }
}
