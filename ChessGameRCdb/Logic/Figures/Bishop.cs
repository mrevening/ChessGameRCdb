﻿using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Bishop : Figure
    {
        public override FigureType FigureType { get => FigureType.Bishop; }
        public override List<IActiveAction> MoveTypes { get => new List<IActiveAction>() { new AllDirectionDiagonal() }; }
        public override List<IPassiveAttack> AttackTypes { get => new List<IPassiveAttack>() { new OpenAttackDiagnonal(), new DefferedCheckDiagonal() }; }

        public Bishop(Color player) : base(player) { }
        public Bishop(Color player, Column column, Row row) : base(player, column, row) { }
        public Bishop(Color player, Coordinate position) : base(player, position) { }

    }
}
