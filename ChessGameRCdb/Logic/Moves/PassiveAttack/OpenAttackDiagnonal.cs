using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    internal class OpenAttackDiagnonal : PassiveAttack
    {
        public override IEnumerable<AttackOption> AddAttackOptions(HashSet<AttackOption> allAttackOptions, IBoard board, IFigure figure)
        {
            var directions = new List<IMoveDirection>() { new NE(), new NW(), new SE(), new SW() };

            directions.ForEach(d =>
            {
                var c = d.GetCoordinates(figure);
                AddOpenAttack(allAttackOptions, board, figure, c);
            });

            return allAttackOptions;
        }
    }
}
