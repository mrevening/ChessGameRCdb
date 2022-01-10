using ChessGame.Logic.Enums;
using ChessGame.Logic.Interfaces;
using ChessGame.Logic.SeedWork;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Logic.Definitions
{
    public class Board : IBoard
    {
        public List<IFigure> Figures { get; private set; }
        public List<MoveLog> Logs { get; private set; }

        public Board(IEnumerable<IFigure> startBoardSetup)
        {
            Figures = new List<IFigure>(startBoardSetup);
        }

        public bool IsPlayersFigure(Player player, Coordinate endPoint)
        {
            return Figures.Any(x => x.IsPlayersFigure(player, endPoint));
        }
        public bool IsEnemysFigure(Player player, Coordinate endPoint)
        {
            return Figures.Any(x => x.IsEnemysFigure(player, endPoint));
        }
        public bool IsEmptyField(Coordinate endPoint) => !Figures.Any(x => x.IsInPosition(endPoint));

        public IFigure? GetFigure(Column column, Row row) => GetFigure(new Coordinate(column, row));
        public IFigure? GetFigure(Coordinate endPoint) { return Figures.FirstOrDefault(x => x.IsInPosition(endPoint)); }
        public void MoveFigure(IFigure currentFigure, Coordinate endPoint)
        {
            var enemyFigure = GetFigure(endPoint);
            if (enemyFigure != null) Figures.Remove(enemyFigure);
            currentFigure.SetPosition(endPoint);
        }
    }
}
