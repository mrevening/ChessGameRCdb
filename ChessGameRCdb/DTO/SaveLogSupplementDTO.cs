using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class SaveLogSupplementDTO
    {
        public string StartPoint { get; private set; }
        public string EndPoint { get; private set; }
        public int? Figure { get; private set; }
    }
}
