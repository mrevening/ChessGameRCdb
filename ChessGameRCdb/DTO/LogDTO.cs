using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class LogDTO
    {
        public string StartPoint { get; private set; }
        public string EndPoint { get; private set; }
        public IEnumerable<LogSupplementDTO> LogSupplement { get; private set; }

        public LogDTO(Log log)
        {
            StartPoint = log.StartPoint.ToString();
            EndPoint = log.EndPoint.ToString();
            LogSupplement = log.LogComplexMove.Select(x => new LogSupplementDTO(x));
        }
    }
}
