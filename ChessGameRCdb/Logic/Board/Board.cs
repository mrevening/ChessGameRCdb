using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Board : IBoard
    {
        public List<IFigure> Figures { get; private set; }
        private BoardValidator BoardValidator { get; }

        public Board(IEnumerable<IFigure> startBoardSetup)
        {
            Figures = new List<IFigure>(startBoardSetup);
            BoardValidator = new BoardValidator();
        }

        public void EvaluateBoard(Color color)
        {
            Figures.Where(x => x.Color != color).ToList().ForEach(x => x.AttackTypes.ForEach(y => y.AddAttackOptions(x.AttackOptions, this, x)));
            Figures.Where(x => x.Color == color).ToList().ForEach(x => x.MoveTypes.ForEach(y => x.MoveOptions.UnionWith(y.AddMoveOptions(x.MoveOptions, this, x, new List<Log>()))));

            this.EvaluateMoveOptions(color);
        }

        public void EvaluateBoard(IEnumerable<Log> previousLogs) {
            var previousLog = previousLogs.TakeLast(1).FirstOrDefault();
            var color = !this.GetCurrentColor(previousLog.EndPoint);
            Figures.Where(x => x.Color != color).ToList().ForEach(x => x.AttackTypes.ForEach(y => y.AddAttackOptions(x.AttackOptions, this, x)));
            Figures.Where(x => x.Color == color).ToList().ForEach(x => x.MoveTypes.ForEach(y => x.MoveOptions.UnionWith(y.AddMoveOptions(x.MoveOptions, this, x, previousLogs))));
            this.EvaluateMoveOptions(color);
        }
        public void ExecuteLog(Log log)
        {
            BoardValidator.ValidateLogs(this, log);
            this.MoveFigure(log);
            if (log.EnPassant != null) this.HandleEnPassant(log);
            if (log.Castle != null) this.HandleCastle(log);
            if (log.Promotion != null) this.HandlePromotion(log);
        }
    }
}
