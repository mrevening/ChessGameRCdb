using ChessGame.DTO;
using System.Collections.Generic;

namespace ChessGame.Interface
{
    public interface IBoardQuery
    {
        IEnumerable<FigureDTO> GetBoard(int id);
    }
}
