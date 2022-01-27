using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class BoardBuilder : IBoardBuilder
    {
        public IBoard CreateBoardFromLogs(IEnumerable<IFigure> figures, IEnumerable<Log> logs)
        {
            return new Board(BoardSetup.GetInstance().GetStandardSetup(), Color.White);
        }
    }
}
