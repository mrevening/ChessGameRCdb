using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic
{
    public class Board : IBoard
    {
        public List<IFigure> Figures { get; private set; }
        public List<Log> Logs { get; private set; }
        public Color CurrentPlayerColor { get; private set; }

        public Board(IEnumerable<IFigure> startBoardSetup, Color currentPlayerColor, List<Log> logs)
        {
            CurrentPlayerColor = currentPlayerColor;
            Figures = new List<IFigure>(startBoardSetup);
            Logs = logs;
        }

        public bool IsPlayersFigure(Color player, Coordinate endPoint) => Figures.Any(x => x.IsPlayersFigure(player, endPoint));
        public bool IsEnemysFigure(Color player, Coordinate endPoint) => Figures.Any(x => x.IsEnemysFigure(player, endPoint));
        public IFigure? GetFigure(Column column, Row row) => GetFigure(new Coordinate(column, row));
        public IFigure? GetFigure(Coordinate endPoint) => Figures.FirstOrDefault(x => x.IsInPosition(endPoint));
        public bool IsEmptyField(Coordinate c) => GetFigure(c) == null;
        public void MoveFigure(IFigure currentFigure, Coordinate endPoint)
        {
            var enemyFigure = GetFigure(endPoint);
            if (enemyFigure != null) Figures.Remove(enemyFigure);
            currentFigure.SetPosition(endPoint);
        }
    }
}
