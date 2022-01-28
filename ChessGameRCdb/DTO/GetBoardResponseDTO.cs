using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class GetBoardResponseDTO
    {
        public IEnumerable<FigureDTO> Figures { get; set; }
    }
}
