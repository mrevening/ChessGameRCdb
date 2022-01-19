using ChessGame.DTO;
using System.Collections.Generic;

namespace ChessGame.HubMove
{
    public class MoveMessage
    {
        public IEnumerable<FigureDTO> Board { get; set; }
    }
}