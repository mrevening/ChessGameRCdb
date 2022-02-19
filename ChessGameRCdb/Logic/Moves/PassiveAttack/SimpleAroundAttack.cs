using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class SimpleAroundAttack : PassiveAttack
    {
        public override IEnumerable<AttackOption> AddAttackOptions(HashSet<AttackOption> allAttackOptions, IBoard board, IFigure figure)
        {
            var coordinates = GetSimpleAllAroundCoordinates(board, figure);
            allAttackOptions.UnionWith(coordinates.Select(c => new AttackOption(AttackType.OpenAttack, c)));

            return allAttackOptions;
        }
    }
}
