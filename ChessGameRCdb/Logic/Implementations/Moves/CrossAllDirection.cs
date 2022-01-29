using ChessGame.Logic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class CrossAllDirection : LongDistance, IMove
    {
        
        public override IEnumerable<MoveOption> GetMoveOptions(IBoard board, IFigure figure, Direction direction)
        {
            if (board.IsEnemysFigure(board.CurrentPlayerColor, figure.Coordinate)) return new List<MoveOption>();
            var isUp = direction == Direction.Up;

            List<MoveOption> allMoveOptions = new List<MoveOption>();
            var coordinatesUp = Enumeration.GetAll<Row>(isUp).Where(row => row > figure.Coordinate.Row).Select(r => new Coordinate(figure.Coordinate.Column, r));
            var coordinatesDown = Enumeration.GetAll<Row>(isUp).Where(row => row < figure.Coordinate.Row).Select(r => new Coordinate(figure.Coordinate.Column, r));
            var coordinatesLeft = Enumeration.GetAll<Column>(isUp).Where(col => col > figure.Coordinate.Column).Select(c => new Coordinate(c, figure.Coordinate.Row));
            var coordinatesRight = Enumeration.GetAll<Column>(isUp).Where(col => col < figure.Coordinate.Column).Select(c => new Coordinate(c, figure.Coordinate.Row));


            AddLongDistanceActions(allMoveOptions, board, figure, coordinatesUp);
            AddLongDistanceActions(allMoveOptions, board, figure, coordinatesDown);
            AddLongDistanceActions(allMoveOptions, board, figure, coordinatesLeft);
            AddLongDistanceActions(allMoveOptions, board, figure, coordinatesRight);

            return allMoveOptions;
        }
    }
}
