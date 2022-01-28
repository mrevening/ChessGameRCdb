using ChessGame.DTO;
using System.Collections.Generic;

namespace ChessGame.HubMove
{
    public class UpdateBoardDTO
    {
        public IEnumerable<FigureDTO> Board { get; set; }
    }
}