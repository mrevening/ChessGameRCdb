using System.Collections.Generic;

namespace ChessGame.Logic
{
    public class Pawn : Figure
    {
        public override FigureType FigureType { get => FigureType.Pawn; }
        public override List<IActiveAction> MoveTypes { get => new List<IActiveAction>() { new OneTileForwardMove(), new TwoTilesForwardMove(), new OneTileDiagonalCapture(), new EnPassant() }; }
        public override List<IPassiveAttack> AttackTypes { get => new List<IPassiveAttack>() { new SimpleDiagonalAttack() }; }

        public Pawn(Color player) : base(player) { }
        public Pawn(Color player, Column column, Row row) : base(player, column, row) { }
        public Pawn(Color player, Coordinate position) : base( player, position) { }
        public Pawn(Color player, string position) : base(player, position) { }
    }
}
