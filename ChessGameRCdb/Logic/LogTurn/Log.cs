namespace ChessGame.Logic
{
    public class Log
    {
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }

        public bool? Castle { get; private set; }
        public bool? EnPassant { get; private set; }
        public int? Promotion { get; private set; }
        public Log(string startPoint, string endPoint)
        {
            StartPoint = new Coordinate(startPoint);
            EndPoint = new Coordinate(endPoint);
        }
        public Log(Coordinate startPoint, Coordinate endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public Log(string startPoint, string endPoint, bool? castle, bool? enPassant, int? promotedFigure)
        {
            StartPoint = new Coordinate(startPoint);
            EndPoint = new Coordinate(endPoint);
            Castle = castle;
            EnPassant = enPassant;
            Promotion = promotedFigure;
        }

        public void SetEnPassant() => EnPassant = true;
        public void SetCastle() => Castle = true;
        public void SetPromotion(int figureType) => Promotion = figureType;

        public override string ToString() => StartPoint.ToString() + EndPoint.ToString();
        public override bool Equals(object obj) => obj != null && Equals(obj as Log);
        public bool Equals(Log log) => StartPoint == log.StartPoint && EndPoint == log.EndPoint;
        public override int GetHashCode() => (StartPoint, EndPoint).GetHashCode();
    }
}
