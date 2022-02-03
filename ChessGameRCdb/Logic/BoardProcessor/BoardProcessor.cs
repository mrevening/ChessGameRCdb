using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ChessGame.Logic
{
    public class BoardProcessor : IBoardProcessor
    {
        private IBoard Board { get; }

        public BoardProcessor(IBoard inputBoard) {
            Board = inputBoard;
        }

        public IBoard CalculateInitBoard(Color startPlayer)
        {
            Board.EvaluateInitBoard(startPlayer);

            return new Board(ImmutableList.CreateRange(Board.Figures).ToImmutableList());
        }

        public IBoard CalculateBoard(List<Log> logs)
        {
            logs.ForEach(log => Board.ExecuteLog(log));
            Board.EvaluateBoard(logs.TakeLast(1).FirstOrDefault(), logs.SkipLast(1).TakeLast(1).FirstOrDefault());

            return new Board(ImmutableList.CreateRange(Board.Figures).ToImmutableList());
        }
    }
}
