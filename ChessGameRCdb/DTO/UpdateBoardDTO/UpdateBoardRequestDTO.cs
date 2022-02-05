using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class UpdateBoardRequestDTO
    {
        public int GameId {get;set;}
        public IEnumerable<FigureUpdateDTO> Figures { get; set; }
        public SaveLogDTO Log { get; set; }
    }
}
