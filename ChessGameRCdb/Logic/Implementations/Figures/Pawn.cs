using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Pawn : Figure
    {
        public override FigureType FigureType { get { return FigureType.Pawn; } }
        public override List<IMove> MoveTypes { get => new List<IMove>() { new OneTileForward(), new TwoTilesForward(), new EnPassant() }; }

        public Pawn(Color player) : base(player) { }
        public Pawn(Color player, Column column, Row row) : base(player, column, row) { }
        public Pawn(Color player, Coordinate position) : base( player, position) { }

        public override bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint)
        {
            return true;
        }
    }
}
