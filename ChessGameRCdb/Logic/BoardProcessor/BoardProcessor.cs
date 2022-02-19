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

        public IBoard CalculateInitBoard(Color startPlayer = null)
        {
            Board.EvaluateInitBoard(startPlayer ?? Color.White);

            return new Board(ImmutableList.CreateRange(Board.Figures).ToImmutableList());
        }

        public IBoard CalculateBoard(List<Log> logs = null)
        {
            if (logs == null || !logs.Any()) CalculateInitBoard();
            else
            {
                logs.ForEach(log => Board.ExecuteLog(log));
                Board.EvaluateBoard(logs);
            };

            return new Board(ImmutableList.CreateRange(Board.Figures).ToImmutableList());
        }
    }
}
