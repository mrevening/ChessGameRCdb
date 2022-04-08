using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ChessGame.Logic
{
    public class BoardProcessor : IBoardProcessor
    {
        private IBoard Board { get; }
        private IEnumerable<Log> Logs{ get; }

        public BoardProcessor(IBoard inputBoard)
        {
            Board = inputBoard;
            Logs = new List<Log>();
        }

        public BoardProcessor(IBoard inputBoard, IEnumerable<Log> logs) {
            Board = inputBoard;
            Logs = logs;
        }

        public IBoard CalculateBoard(Log log)
        {
            Board.ExecuteLog(log);
            Board.EvaluateBoard(Logs);

            return new Board(ImmutableList.CreateRange(Board.Figures).ToImmutableList());
        }

        public IBoard CalculateBoard()
        {
            if (Logs == null || !Logs.Any()) Board.EvaluateBoard(Color.White);
            else
            {
                Logs.ToList().ForEach(log => Board.ExecuteLog(log));
                Board.EvaluateBoard(Logs);
            };

            return new Board(ImmutableList.CreateRange(Board.Figures).ToImmutableList());
        }

        public IBoard CalculateBoard(Color color)
        {
            Board.EvaluateBoard(color);

            return new Board(ImmutableList.CreateRange(Board.Figures).ToImmutableList());
        }
    }
}
