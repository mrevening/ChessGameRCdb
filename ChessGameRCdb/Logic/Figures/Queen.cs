using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Queen : Figure
    {
        public override FigureType FigureType { get => FigureType.Queen; }
        public override List<IActiveAction> MoveTypes { get => new List<IActiveAction>() { new AllDirection(), new AllDirectionDiagonal() }; }
        public override List<IPassiveAttack> AttackTypes { get => new List<IPassiveAttack>() { new OpenAttack(), new OpenAttackDiagnonal(), new DefferedCheck(), new DefferedCheckDiagonal() }; }

        public Queen(Color player) : base(player) { }
        public Queen(Color player, Column column, Row row) : base(player, column, row) { }
        public Queen(Color player, Coordinate position) : base(player, position) { }

    }
}
