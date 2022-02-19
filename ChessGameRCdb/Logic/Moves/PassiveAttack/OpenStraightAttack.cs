using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OpenStraightAttack : PassiveAttack
    {
        public override IEnumerable<AttackOption> AddAttackOptions(HashSet<AttackOption> allAttackOptions, IBoard board, IFigure figure)
        {
            var directions = new List<IMoveDirection>() { new Up(), new Down(), new Left(), new Right() };

            directions.ForEach(d =>
            {
                var c = d.GetCoordinates(figure);
                AddOpenAttack(allAttackOptions, board, figure, c);
            });

            return allAttackOptions;
        }
    }
}
