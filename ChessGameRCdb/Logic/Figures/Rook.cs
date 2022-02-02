using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class Rook : Figure
    {
        public override FigureType FigureType { get => FigureType.Rook; }
        public override List<IMove> MoveTypes { get => new List<IMove>() { new CrossAllDirection() }; }

        public Rook(Color player) : base(player) { }
        public Rook(Color player, Column column, Row row) : base(player, column, row) { }
        public Rook(Color player, Coordinate position) : base(player, position) { }

    }
}
