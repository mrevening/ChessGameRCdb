using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Bishop : Figure
    {
        public override FigureType FigureType { get { return FigureType.Bishop; } }
        public override List<IMove> MoveTypes { get => new List<IMove>() { new CrossAllDirection() }; }

        public Bishop(Color player) : base(player) { }
        public Bishop(Color player, Column column, Row row) : base(player, column, row) { }
        public Bishop(Color player, Coordinate position) : base(player, position) { }

        public override bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint)
        {
            return true;
        }
    }
}
