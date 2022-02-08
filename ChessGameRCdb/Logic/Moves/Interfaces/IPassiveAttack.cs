using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGame.Logic
{
    public interface IPassiveAttack
    {
        IEnumerable<AttackOption> AddAttackOptions(HashSet<AttackOption> allMoveOptions, IBoard board, IFigure figure);
    }
}
