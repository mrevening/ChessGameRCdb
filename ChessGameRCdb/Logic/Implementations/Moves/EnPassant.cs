using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class EnPassant : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction)
        {
            var allMoveOptions = new List<MoveOption>();
            if (InitCheck(board, figure)) return allMoveOptions;
            if (board.Logs.Count <= 0) return allMoveOptions;
            var lastLog = board.Logs.TakeLast(1).FirstOrDefault();
            var lastEnemySFigureMoved = board.GetFigure(lastLog.StartPoint);
            if (lastEnemySFigureMoved.FigureType != FigureType.Pawn) return allMoveOptions;
            //var currentFigureRow = figure.Coordinate.Row;
            //if (lastEnemySFigureMoved.Coordinate.Column)



            //var isUp = direction == Direction.Up;
            //var enPassantRow = isUp ? Row.Five : Row.Four;
            //var enemysLastMoveLeft = isUp ? Row.Five : Row.Four;
            
            //var isPlayersFigureInEnPassantPosition = figure.Coordinate.Row == enPassantRow;
            //figure.Coordinate.

            return allMoveOptions;
        }
    }
}
