using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class DefferedCheckDiagonal : PassiveAttack
    {
        public override IEnumerable<AttackOption> AddAttackOptions(HashSet<AttackOption> allAttackOptions, IBoard board, IFigure figure)
        {
            var directions = new List<IMoveDirection>() { new NW(), new SW(), new SE(), new NE() };

            directions.ForEach(d =>
            {
                var c = d.GetCoordinates(figure);
                AddDefferedAttack(allAttackOptions, board, figure, c);
            });
            return allAttackOptions;
        }
    }
}
