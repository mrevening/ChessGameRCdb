using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Pawn : Figure
    {
        public override FigureType FigureType { get { return FigureType.Pawn; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public Pawn(Color player) : base(player) { }
        public Pawn(Color player, Column column, Row row) : base(player, column, row) { }
        public Pawn(Color player, Coordinate position) : base( player, position) { }

        public override bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint)
        {
            return true;
        }
        public override IEnumerable<MoveOption> MoveOptions(IBoard board)
        {
            if (board.IsEnemysFigure(board.CurrentPlayerColor, Coordinate))
            {
                return new List<MoveOption>();
            }

            List<MoveOption> allMoveOptions = new List<MoveOption>();
            var coordinatesUp = Enumeration.GetAll<Row>().Where(row => row > Coordinate.Row).Select(r => new Coordinate(Coordinate.Column, r));
            var coordinatesDown = Enumeration.GetAll<Row>().Where(row => row < Coordinate.Row).Select(r => new Coordinate(Coordinate.Column, r));
            var coordinatesLeft = Enumeration.GetAll<Column>().Where(col => col > Coordinate.Column).Select(c => new Coordinate(c, Coordinate.Row));
            var coordinatesRight = Enumeration.GetAll<Column>().Where(col => col < Coordinate.Column).Select(c => new Coordinate(c, Coordinate.Row));

            AddLongDistanceActions(allMoveOptions, board, coordinatesUp);
            AddLongDistanceActions(allMoveOptions, board, coordinatesDown);
            AddLongDistanceActions(allMoveOptions, board, coordinatesLeft);
            AddLongDistanceActions(allMoveOptions, board, coordinatesRight);

            return allMoveOptions;
        }
    }
}
