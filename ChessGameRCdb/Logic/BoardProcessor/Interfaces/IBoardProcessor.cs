using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IBoardProcessor
    {
        IBoard CalculateBoard(List<Log> logs);
    }
}
