using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class LogDTO
    {
        public string Start { get; set; }
        public string End { get; set; }
        public string EnPassant { get; set; }

        public LogDTO() { }
        public LogDTO(Log log)
        {
            Start = log.StartPoint.ToString();
            End = log.EndPoint.ToString();
            EnPassant = log.EnPassant?.ToString();
        }
    }
}
