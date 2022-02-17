using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class PassiveAttack : Move, IPassiveAttack
    {
        public abstract IEnumerable<AttackOption> AddAttackOptions(HashSet<AttackOption> allMoveOptions, IBoard board, IFigure figure);

        protected void AddOpenAttack(HashSet<AttackOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            var coordinatesFreeToAttack = coordinates.TakeWhile(c => board.IsEmptyField(c));
            allMoveOptions.UnionWith(coordinatesFreeToAttack.Select(c => new AttackOption(AttackType.OpenAttack, c)));
        }
        protected void AddDefferedAttack(HashSet<AttackOption> allMoveOptions, IBoard board, IFigure figure, IEnumerable<Coordinate> coordinates)
        {
            var k = board.Figures.SingleOrDefault(f => f.FigureType == FigureType.King && f.Color == !figure.Color);
            if (k is null) return;
            var isK = coordinates.Any(c => c == k.Coordinate);
            if (!isK) return;

            var figuresToEnemyKing = coordinates.TakeWhile(c => c != k.Coordinate).Select(c => board.Figures.FirstOrDefault(X => X.Coordinate == c)).ToList();
            figuresToEnemyKing.RemoveAll(x => x is null);
            if (figuresToEnemyKing.Count == 1 && figuresToEnemyKing.First().Color != figure.Color) allMoveOptions.Add(new AttackOption(AttackType.DefferedCheck, figuresToEnemyKing.First().Coordinate));
            else return;
        }
    }
}