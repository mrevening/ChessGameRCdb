using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IBoardProcessor
    {
        IBoard CalculateBoard();
        IBoard CalculateBoard(Log log);
    }
}
