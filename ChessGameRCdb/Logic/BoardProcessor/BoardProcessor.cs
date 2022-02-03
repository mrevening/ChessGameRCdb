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
            logs.ForEach(log => board.ExecuteLog(log));
            board.EvaluateBoard(logs.TakeLast(1).FirstOrDefault(), logs.SkipLast(1).TakeLast(1).FirstOrDefault());

            return new Board(ImmutableList.CreateRange(board.Figures).ToImmutableList());
        }
    }
}
