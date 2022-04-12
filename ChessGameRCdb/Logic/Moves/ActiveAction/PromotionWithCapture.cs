//using System.Collections.Generic;

//namespace ChessGame.Logic
//{
//    internal class PromotionWithCapture : ActiveAction
//    {
//        public override IEnumerable<MoveOption> AddMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Log> previousLogs)
//        {
//            var isUp = figure.Color.IsUp();
//            var promotedRow = isUp ? Row.Seven : Row.Two;
//            if (figure.Coordinate.Row != promotedRow) return allMoveOptions;
//            var endRow = isUp ? Row.Eight : Row.One;
//            var color = figure.Color;
//            var coordinates = new List<Coordinate>
//            {
//                new Coordinate(figure.Coordinate.Column.Id - 1, endRow.Id),
//                new Coordinate(figure.Coordinate.Column.Id + 1, endRow.Id)
//            };
//            coordinates.ForEach(c =>
//            {
//                if (board.IsOpponentFigure(c, color)) allMoveOptions.Add(new MoveOption(ActionType.PromotionWithCapture, new Log(figure.Coordinate, c)));
//            });  
//            return allMoveOptions;
//        }
//    }
//}
