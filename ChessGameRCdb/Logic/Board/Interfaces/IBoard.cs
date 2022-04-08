using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IBoard
    {
        List<IFigure> Figures { get; }
        void EvaluateBoard(Color color);
        void EvaluateBoard(IEnumerable<Log> previousLogs);
        void ExecuteLog(Log log);
    }
}
