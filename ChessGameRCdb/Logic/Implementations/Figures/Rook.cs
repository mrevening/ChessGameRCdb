using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Rook : Figure
    {
        public override FigureType FigureType { get { return FigureType.Rook; } }
        public override IEnumerable<IMove> PossibleMoves { get => new List<IMove>() { MoveType.DiagonalAllDirection }; }

        public Rook(Color player) : base(player) { }
        public Rook(Color player, Column column, Row row) : base(player, column, row) { }
        public Rook(Color player, Coordinate position) : base(player, position) { }

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
            return new List<MoveOption>();
        }
    }
}
