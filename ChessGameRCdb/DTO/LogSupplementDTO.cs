using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class LogSupplementDTO
    {
        public string StartPoint { get; private set; }
        public string EndPoint { get; private set; }
        public int? Figure { get; private set; }

        public LogSupplementDTO(LogComplexMove log)
        {
            StartPoint = log.StartPoint?.ToString();
            EndPoint = log.EndPoint?.ToString();
            Figure = log.FigureType?.Id;
        }
    }
}
