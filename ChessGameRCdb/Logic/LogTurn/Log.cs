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


        public override bool Equals(object obj)
        {
            var stu = obj as Log;
            if (stu == null) return false;
            return StartPoint.ToString() == stu.StartPoint.ToString() && EndPoint.ToString() == stu.EndPoint.ToString();
        }
        public override int GetHashCode()
        {
            return StartPoint.ToString().GetHashCode() * EndPoint.ToString().GetHashCode();
        }
    }
}
