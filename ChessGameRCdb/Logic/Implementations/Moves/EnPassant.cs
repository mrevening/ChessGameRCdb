using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class EnPassant : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure f, Direction direction)
        {
            var allMoveOptions = new List<MoveOption>();
            if (InitCheck(board, f)) return allMoveOptions;
            if (board.Logs.Count <= 0) return allMoveOptions;
            var log = board.Logs.TakeLast(1).FirstOrDefault();
            var eF = board.GetFigure(log.EndPoint);
            var isUp = direction == Direction.Up;
            var col = f.Coordinate.Column;
            var r = isUp ? Row.Five : Row.Four;
            var eSR = isUp ? Row.Seven : Row.Two;
            var eER = isUp ? Row.Five : Row.Four;
            var eCols =  new List<Column>() { col + 1, col - 1 };
            var i = isUp ? 1 : -1;
            eCols.Remove(null);

            if (eF.FigureType != FigureType.Pawn 
                || f.Coordinate.Row != r 
                || !eCols.Exists(c => c == eF.Coordinate.Column) 
                || log.StartPoint.Row != eSR
                || log.EndPoint.Row != eER
            ) return allMoveOptions;

            allMoveOptions.Add(new MoveOption(new Coordinate(eF.Coordinate.Column, f.Coordinate.Row + i), new List<ActionType>() { ActionType.Move, ActionType.Capture, ActionType.EnPassant }));
            return allMoveOptions;
        }
    }
}
