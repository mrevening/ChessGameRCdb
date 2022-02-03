using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Log
    {
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }
        public List<LogComplexMove> LogComplexMove { get; private set; }
        //public List<LogComplexMove> LogPromotion { get; private set; }
        public Log(Coordinate startPoint, Coordinate endPoint, List<LogComplexMove> logComplexMove = null)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            LogComplexMove = logComplexMove ?? new List<LogComplexMove>();
        }
        public override string ToString() => StartPoint.ToString() + EndPoint.ToString();
        public override bool Equals(object obj) => obj != null && Equals(obj as Log);
        public bool Equals(Log log) => StartPoint == log.StartPoint && EndPoint == log.EndPoint;
        public override int GetHashCode() => (StartPoint, EndPoint).GetHashCode();
    }
}
