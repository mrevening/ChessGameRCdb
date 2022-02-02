namespace ChessGame.Logic
{
    public class LogComplexMove : Log
    {
        public FigureType FigureType { get; private set; }

        public LogComplexMove(Coordinate startPoint, Coordinate endPoint, FigureType figure) : base(startPoint, endPoint)
        {
            FigureType = figure;
        }
    }
}
