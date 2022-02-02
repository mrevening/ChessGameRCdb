using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ChessGame.Logic
{
    public class BoardProcessor : IBoardProcessor
    {
        public IBoard OutputBoard { get; private set; }

        public BoardProcessor(IBoard inputBoard, List<Log> logs)
        {
            OutputBoard = CalculateBoard(inputBoard, logs);
        }

        private IBoard CalculateBoard(IBoard board, List<Log> logs)
        {
            logs.ToList().ForEach(log => board.ExecuteLog(log));
            logs.TakeLast(1).ToList().ForEach(log => board.EvaluateBoard(log, logs.TakeLast(2).FirstOrDefault()));

            return new Board(ImmutableList.CreateRange(board.Figures).ToImmutableList());
        }
    }
}
