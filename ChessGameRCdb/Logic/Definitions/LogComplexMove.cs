namespace ChessGame.Logic
{
    public class LogComplexMove
    {
        public LogComplexMove(Coordinate startPoint, Coordinate endPoint, FigureType figure)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            FigureType = figure;
        }
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }
        public FigureType FigureType { get; private set; }
    }
}
