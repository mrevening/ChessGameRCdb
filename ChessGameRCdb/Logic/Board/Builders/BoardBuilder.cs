using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class BoardBuilder : IBoardBuilder
    {
        public IBoard CreateBoardFromLogs(IEnumerable<IFigure> figures, IEnumerable<Log> logs)
        {
            return new Board(BoardSetup.GetInstance().GetStandardSetup(), Color.White, logs.ToList());;
        }
    }
}
