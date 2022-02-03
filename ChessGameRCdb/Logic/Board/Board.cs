using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Board : IBoard
    {
        public List<IFigure> Figures { get; private set; }

        public Board(IEnumerable<IFigure> startBoardSetup)
        {
            Figures = new List<IFigure>(startBoardSetup);
        }

        public void EvaluateInitBoard(Color color)
        {
            Figures.Where(x => x.Color == color).ToList().ForEach(x => x.MoveTypes.ForEach(y => x.MoveOptions.UnionWith(y.GetMoveOptions(x.MoveOptions, this, x, null))));
        }
        public void ExecuteLog(Log log)
        {
            var color = this.GetCurrentColor(log);
            this.SetPosition(log, color);
            log.LogComplexMove.ForEach(supplement => this.HandleExtraMove(supplement, color));
        }
        public void EvaluateBoard(Log log, Log previousLog) {
            var direction = this.GetCurrentColor(log) == Color.White ? Direction.Up : Direction.Down;
            Figures.ForEach(x => x.MoveTypes.ForEach(y => x.MoveOptions.UnionWith(y.GetMoveOptions(x.MoveOptions, this, x, previousLog))));
        }
    }
}
