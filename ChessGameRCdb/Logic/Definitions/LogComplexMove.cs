namespace ChessGame.Logic
{
    public class LogComplexMove
    {
        public LogComplexMove(Coordinate startPoint, Coordinate endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }
        public Log Log { get; private set; }
    }
}
