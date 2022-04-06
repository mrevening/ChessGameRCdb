using System;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Log
    {
        public Coordinate StartPoint { get; private set; }
        public Coordinate EndPoint { get; private set; }

        public LogEnPassant EnPassant { get; private set; }
        //public LogComplexMove Promotion { get; private set; }
        //public LogComplexMove Castle { get; private set; }

        public Log(string startPoint, string endPoint)
        {
            StartPoint = new Coordinate(startPoint);
            EndPoint = new Coordinate(endPoint);
        }
        public Log(string startPoint, string endPoint, string enPassant)
        {
            StartPoint = new Coordinate(startPoint);
            EndPoint = new Coordinate(endPoint);
            EnPassant = new LogEnPassant(enPassant);
        }
        public Log(Coordinate startPoint, Coordinate endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public Log(Coordinate startPoint, Coordinate endPoint, LogEnPassant enPassant)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            EnPassant = enPassant;
        }

        public override string ToString() => StartPoint.ToString() + EndPoint.ToString();
        public override bool Equals(object obj) => obj != null && Equals(obj as Log);
        public bool Equals(Log log) => StartPoint == log.StartPoint && EndPoint == log.EndPoint;
        public override int GetHashCode() => (StartPoint, EndPoint).GetHashCode();
    }
}
