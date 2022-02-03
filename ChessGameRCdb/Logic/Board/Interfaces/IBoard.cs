using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IBoard
    {
        List<IFigure> Figures { get; }
        void EvaluateInitBoard(Color color);
        void ExecuteLog(Log log);
        void EvaluateBoard(Log currentLog, Log previousLog);
    }
}
