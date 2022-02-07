using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class ExecuteMoveRequestDTO
    {
        public int GameID { get; set; }
        public IEnumerable<FigureDTO> Figures { get; set; }
        public MoveOptionDTO Move { get; set; }
    }
}
