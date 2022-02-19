using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Queen : Figure
    {
        public override FigureType FigureType { get => FigureType.Queen; }
        public override List<IActiveAction> MoveTypes { get => new List<IActiveAction>() { new AllDirectionStraight(), new AllDirectionDiagonal() }; }
        public override List<IPassiveAttack> AttackTypes { get => new List<IPassiveAttack>() { new OpenStraightAttack(), new OpenDiagonalAttack(), new DefferedStraightCheck(), new DefferedDiagonalCheck() }; }

        public Queen(Color player) : base(player) { }
        public Queen(Color player, Column column, Row row) : base(player, column, row) { }
        public Queen(Color player, Coordinate position) : base(player, position) { }
        public Queen(Color player, string position) : base(player, position) { }
    }
}
