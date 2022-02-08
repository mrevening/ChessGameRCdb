using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class DefferedCheck : PassiveAttack
    {
        public override IEnumerable<AttackOption> AddAttackOptions(HashSet<AttackOption> allAttackOptions, IBoard board, IFigure figure)
        {
            var directions = new List<IMoveDirection>() { new Up(), new Down(), new Left(), new Right() };
            directions.RemoveAll(d => d is null);
            directions.ForEach(d =>
            {
                var c = d.GetCoordinates(figure);
                AddDefferedAttack(allAttackOptions, board, figure, c);
            });
            return allAttackOptions;
        }
    }
}
