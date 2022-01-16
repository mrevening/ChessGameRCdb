using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class MoveDTO
    {
        public int GameId { get; set; }
        public int ColumnStart { get; set; }
        public int RowStart { get; set; }
        public int ColumnEnd { get; set; }
        public int RowEnd { get; set; }

        public MoveDTO(int gameId, int columnStart, int rowstart, int columnEnd, int rowEnd) 
        {
            GameId = gameId;
            ColumnStart = columnStart;
            RowStart = rowstart;
            ColumnEnd = columnEnd;
            RowEnd = rowEnd;
        }
    }
}
