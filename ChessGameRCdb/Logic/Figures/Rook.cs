using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Rook : Figure
    {
        public override FigureType FigureType { get => FigureType.Rook; }
        public override List<IActiveAction> MoveTypes { get => new List<IActiveAction>() { new AllDirectionStraight() }; }
        public override List<IPassiveAttack> AttackTypes { get => new List<IPassiveAttack>() { new OpenStraightAttack(), new DefferedStraightCheck() }; }

        public Rook(Color player) : base(player) { }
        public Rook(Color player, Column column, Row row) : base(player, column, row) { }
        public Rook(Color player, Coordinate position) : base(player, position) { }
        public Rook(Color player, string position) : base(player, position) { }
    }
}
