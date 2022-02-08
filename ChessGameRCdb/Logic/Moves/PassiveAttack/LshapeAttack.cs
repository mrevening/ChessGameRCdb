using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class LShapeAttack : PassiveAttack
    {
        public override IEnumerable<AttackOption> AddAttackOptions(HashSet<AttackOption> allAttackOptions, IBoard board, IFigure figure)
        {
            var coordinates = GetLShapeCoordinates(board, figure);
            allAttackOptions.UnionWith(coordinates.Select(c => new AttackOption(AttackType.OpenAttack, c)));

            return allAttackOptions;
        }
    }
}
