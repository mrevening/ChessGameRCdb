using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class LogDTO
    {
        public string Start { get; set; }
        public string End { get; set; }
        public IEnumerable<LogSupplementDTO> LogSupplement { get; set; }

        public LogDTO() { }
        public LogDTO(Log log)
        {
            Start = log.StartPoint.ToString();
            End = log.EndPoint.ToString();
            LogSupplement = log.LogComplexMove.Select(x => new LogSupplementDTO(x));
        }
    }
}
