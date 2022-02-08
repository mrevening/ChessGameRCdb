using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Knight : Figure
    {
        public override FigureType FigureType { get => FigureType.Knight; }
        public override List<IActiveAction> MoveTypes { get => new List<IActiveAction>() { new LShape() }; }
        public override List<IPassiveAttack> AttackTypes { get => new List<IPassiveAttack>() { new LShapeAttack() }; }

        public Knight(Color player) : base(player) { }
        public Knight(Color player, Column column, Row row) : base(player, column, row) { }
        public Knight(Color player, Coordinate position) : base(player, position) { }

    }
}
