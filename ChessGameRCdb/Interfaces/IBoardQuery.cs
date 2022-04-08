using ChessGame.DTO;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGame.Interface
{
    public interface IBoardQuery
    {
        GetBoardResponseDTO GetBoard(int gameId);
        IEnumerable<Log> GetLogs(int gameId);
    }
}
