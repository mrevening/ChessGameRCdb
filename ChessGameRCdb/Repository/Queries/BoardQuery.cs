using ChessGame.DTO;
using ChessGame.Infrastructure;
using ChessGame.Interface;
using ChessGame.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Query
{
    public class BoardQuery : IBoardQuery
    {
        private readonly BoardDbContext _context;

        public BoardQuery(BoardDbContext boardContext)
        {
            _context = boardContext;
        }
        public GetBoardResponseDTO GetBoard(int gameId)
        {
            var figures = new List<IFigure>();
            var logs = new List<Log>();
            var game = _context.Game.AsNoTracking()
                .Include(game => game.HostColor)

                .Include(game => game.BoardConfiguration)
                    .ThenInclude(board => board.BoardConfigurationToFigure)
                        .ThenInclude(ctf => ctf.Figure)
                            .ThenInclude(ctf => ctf.Column)
                .Include(game => game.BoardConfiguration)
                    .ThenInclude(board => board.BoardConfigurationToFigure)
                        .ThenInclude(ctf => ctf.Figure)
                            .ThenInclude(ctf => ctf.Row)
                .Include(game => game.BoardConfiguration)
                    .ThenInclude(board => board.BoardConfigurationToFigure)
                        .ThenInclude(ctf => ctf.Figure)
                            .ThenInclude(ctf => ctf.Color)
                .Include(game => game.BoardConfiguration)
                    .ThenInclude(board => board.BoardConfigurationToFigure)
                        .ThenInclude(ctf => ctf.Figure)
                            .ThenInclude(ctf => ctf.FigureType)

                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.StartColumn)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.StartRow)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.EndColumn)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.EndRow)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.NotationLogComplexMove)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.NotationLogComplexMove)
                        .ThenInclude(log => log.StartColumn)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.NotationLogComplexMove)
                        .ThenInclude(log => log.StartRow)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.NotationLogComplexMove)
                        .ThenInclude(log => log.EndColumn)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.NotationLogComplexMove)
                        .ThenInclude(log => log.EndRow)
                .Single(x => x.Id == gameId);

            foreach (var boardConfiguration in game.BoardConfiguration.BoardConfigurationToFigure)
            {
                var dbFigure = boardConfiguration.Figure;
                var player = Enumeration.FromValue<Color>(dbFigure.Color.Id);
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
                foreach (var complexMove in log.NotationLogComplexMove)
                {
                    var startColumnCM = Enumeration.FromValue<Column>(complexMove.StartColumn.Id);
                    var startRowCM = Enumeration.FromValue<Row>(complexMove.StartRow.Id);
                    var endColumnCM = Enumeration.FromValue<Column>(complexMove.EndColumn.Id);
                    var endRowCM = Enumeration.FromValue<Row>(complexMove.EndRow.Id);
                    complexMoves.Add(new LogComplexMove(new Coordinate(startColumnCM, startRowCM), new Coordinate(endColumnCM, endRowCM)));
                }

                logs.Add(new Log(game.Id, new Coordinate(startColumn, startRow), new Coordinate(endColumn, endRow), complexMoves));
            }

            foreach (var log in logs)
            {
                figures.First(x => x.Coordinate == log.StartPoint).SetPosition(log.EndPoint);

                foreach (var supplement in log.LogComplexMove)
                {
                    figures.First(x => x.Coordinate == supplement.StartPoint).SetPosition(supplement.EndPoint);
                }
            }

            var color = logs.Count % 2 == 0 ? Color.White : Color.Black;

            var board = color == Color.White
                ? new MoveWhiteFigure(new Board(figures, color, logs)).InputBoard
                : new MoveBlackFigure(new Board(figures, color, logs)).InputBoard;

            var result = board.Figures.Select((x, i) => new FigureDTO(i, x.FigureType.Id, x.Color.Id, x.Coordinate, x.MoveOptions));

            return new GetBoardResponseDTO { Figures = result };
        }
    }
}
