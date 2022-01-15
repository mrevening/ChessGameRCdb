using ChessGame.Logic;
using ChessGame.Logic;
using ChessGame.Logic;
using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class BoardBuilder : IBoardBuilder
    {
        public IBoard CreateBoardFromLogs(IEnumerable<IFigure> figures, IEnumerable<MoveLog> logs)
        {
            return new Board(BoardSetup.GetInstance().GetStandardSetup());
        }
    }
}
