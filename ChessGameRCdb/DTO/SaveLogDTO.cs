using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class SaveLogDTO
    {
        public int GameId { get; set; }
        public int ColumnStart { get; set; }
        public int RowStart { get; set; }
        public int ColumnEnd { get; set; }
        public int RowEnd { get; set; }
        public IEnumerable<SaveLogSupplementDTO> LogSupplement { get; private set; }
    }
}