using ChessGame.Logic.Definitions;
using ChessGame.Logic.Interfaces;
using ChessGame.Logic.Singletons;
using System.Collections.Generic;

namespace ChessGame.Logic.Builder
{
    public class BoardBuilder : IBoardBuilder
    {
        public IBoard CreateBoardFromLogs(IEnumerable<IFigure> figures, IEnumerable<MoveLog> logs)
        {
            return new Board(BoardSetup.GetInstance().GetStandardSetup());
        }
    }
}
