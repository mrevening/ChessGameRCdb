using System.Collections.Generic;
using System;

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
            List<IFigure>figures = new List<IFigure>();

            foreach (var boardConfiguration in game.BoardConfiguration.BoardConfigurationToFigure)
            {
                var dbFigure = boardConfiguration.Figure;
                var player = Enumeration.FromValue<Player>(dbFigure.Player.Id);
                var figureType = Enumeration.FromValue<FigureType>(dbFigure.FigureType.Id);
                var column = Enumeration.FromValue<Column>(dbFigure.Column.Id);
                var row = Enumeration.FromValue<Row>(dbFigure.Row.Id);
                var coordinate = new Coordinate(column, row);

                var typeName = typeof(IFigure).Namespace + "." + figureType.ToString();
                var figure = (IFigure)Activator.CreateInstance(Type.GetType(typeName), new object[] { player, coordinate });

                figures.Add(figure);
            }

            return new Board(figures);
        }
    }
}
