using System.Collections.Generic;
using System;
using System.Linq;

namespace ChessGame.Logic
{
    public class BoardCreator
    {
        private BoardCreator() { }
        private static BoardCreator _instance;
        public static BoardCreator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BoardCreator();
            }
            return _instance;
        }

        public IBoard CreateBoard(DbModels.Game game)
        {
            var figures = new List<IFigure>();
            var logs = new List<Log>();

            foreach (var boardConfiguration in game.BoardConfiguration.BoardConfigurationToFigure)
            {
                var dbFigure = boardConfiguration.Figure;
                var player = Enumeration.FromValue<Player>(dbFigure.Player.Id);
                var figureType = Enumeration.FromValue<FigureType>(dbFigure.FigureType.Id);
                var column = Enumeration.FromValue<Column>(dbFigure.Column.Id);
                var row = Enumeration.FromValue<Row>(dbFigure.Row.Id);

                var typeName = typeof(IFigure).Namespace + "." + figureType.ToString();
                var figure = (IFigure)Activator.CreateInstance(Type.GetType(typeName), new object[] { player, new Coordinate(column, row) });

                figures.Add(figure);
            }

            foreach (var log in game.NotationLogs)
            {
                var startColumn = Enumeration.FromValue<Column>(log.StartColumn.Id);
                var startRow = Enumeration.FromValue<Row>(log.StartRow.Id);
                var endColumn = Enumeration.FromValue<Column>(log.EndColumn.Id);
                var endRow = Enumeration.FromValue<Row>(log.EndRow.Id);

                var complexMoves = new List<LogComplexMove>();
                foreach(var complexMove in log.NotationLogComplexMove)
                {
                    var startColumnCM = Enumeration.FromValue<Column>(complexMove.StartColumn.Id);
                    var startRowCM = Enumeration.FromValue<Row>(complexMove.StartRow.Id);
                    var endColumnCM = Enumeration.FromValue<Column>(complexMove.EndColumn.Id);
                    var endRowCM = Enumeration.FromValue<Row>(complexMove.EndRow.Id);
                    complexMoves.Add(new LogComplexMove(new Coordinate(startColumnCM, startRowCM), new Coordinate(endColumnCM, endRowCM)));
                }

                logs.Add(new Log(new Coordinate(startColumn, startRow), new Coordinate(endColumn, endRow), complexMoves));
            }

            foreach (var log in logs)
            {
                figures.First(x => x.Coordinate == log.StartPoint).SetPosition(log.EndPoint);

                foreach (var supplement in log.LogComplexMove)
                {
                    figures.First(x => x.Coordinate == supplement.StartPoint).SetPosition(supplement.EndPoint);
                }
            }

            return new Board(figures);
        }
    }
}
