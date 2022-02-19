using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Bishop : Figure
    {
        public override FigureType FigureType { get => FigureType.Bishop; }
        public override List<IActiveAction> MoveTypes { get => new List<IActiveAction>() { new AllDirectionDiagonal() }; }
        public override List<IPassiveAttack> AttackTypes { get => new List<IPassiveAttack>() { new OpenDiagonalAttack(), new DefferedDiagonalCheck() }; }

        public Bishop(Color player) : base(player) { }
        public Bishop(Color player, Column column, Row row) : base(player, column, row) { }
        public Bishop(Color player, Coordinate position) : base(player, position) { }
        public Bishop(Color player, string position) : base(player, position) { }
    }
}
