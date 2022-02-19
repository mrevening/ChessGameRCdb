using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class King : Figure, IUnremovable
    {
        public override FigureType FigureType { get => FigureType.King; }
        public override List<IActiveAction> MoveTypes { get => new List<IActiveAction>() { new AllAroundOneSquare() }; }
        public override List<IPassiveAttack> AttackTypes { get => new List<IPassiveAttack>() { new OpenAttack() }; }

        public King(Color player) : base(player) { }
        public King(Color player, Column column, Row row) : base(player, column, row) { }
        public King(Color player, Coordinate position) : base(player, position) { }
        public King(Color player, string position) : base(player, position) { }
    }
}
