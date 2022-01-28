using ChessGame.DTO;
using System.Collections.Generic;

namespace ChessGame.Interface
{
    public interface IBoardQuery
    {
        GetBoardResponseDTO GetBoard(int gameId);
    }
}
