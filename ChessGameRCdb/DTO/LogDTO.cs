using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class LogDTO
    {
        public string Start { get; set; }
        public string End { get; set; }
        public bool? Castle { get; set; }
        public bool? EnPassant { get; set; }
        public int? Promotion { get; set; }


        public LogDTO() { }
        public LogDTO(Log log)
        {
            Start = log.StartPoint.ToString();
            End = log.EndPoint.ToString();
            Castle = log.Castle;
            EnPassant = log.EnPassant;
            Promotion = log.Promotion;
        }
    }
}
