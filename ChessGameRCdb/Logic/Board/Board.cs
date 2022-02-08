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

        public void EvaluateInitBoard(Color color)
        {
            Figures.Where(x => x.Color == color).ToList().ForEach(x => x.MoveTypes.ForEach(y => x.MoveOptions.UnionWith(y.AddMoveOptions(x.MoveOptions, this, x, null))));
            this.VerifyMoveOptions(color);
        }
        public void ExecuteLog(Log log)
        {
            BoardValidator.ValidateLogs(this, log);
            var color = this.GetCurrentColor(log.StartPoint);
            this.SetPosition(log, color);
            log.LogComplexMove.ForEach(supplement => this.HandleExtraMove(supplement, color));
        }
        public void EvaluateBoard(Log previousLog) {
            var color = this.GetCurrentColor(previousLog.EndPoint).Switch();
            Figures.Where(x => x.Color == color).ToList().ForEach(x => x.MoveTypes.ForEach(y => x.MoveOptions.UnionWith(y.AddMoveOptions(x.MoveOptions, this, x, previousLog))));
            this.VerifyMoveOptions(color);
        }
    }
}
