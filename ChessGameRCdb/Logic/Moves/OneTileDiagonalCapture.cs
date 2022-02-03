using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OneTileDiagonalCapture : Move
    {
        public override IEnumerable<MoveOption> GetMoveOptions(HashSet<MoveOption> allMoveOptions, IBoard board, IFigure figure, Log previousLog)
        {
            var color = figure.Color;
            var i = color.GetDirectionSign();
            var coordinates = new List<Coordinate>
            {
                new Coordinate(figure.Coordinate.Column.Id - 1, figure.Coordinate.Row.Id + i),
                new Coordinate(figure.Coordinate.Column.Id + 1, figure.Coordinate.Row.Id + i)
            };
            coordinates.ForEach(c =>
            {
                if (board.IsOpponentFigure(c, color)) allMoveOptions.Add(new MoveOption(ActionType.Capture, new Log(figure.Coordinate, c)));
            });

            return allMoveOptions;
        }
    }
}

