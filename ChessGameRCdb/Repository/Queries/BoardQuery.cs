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
                    .ThenInclude(log => log.PromotedFigure)

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

                logs.Add(new Log(new Coordinate(startColumn, startRow).ToString(), new Coordinate(endColumn, endRow).ToString(), log.Castle, log.EnPassant, log.PromotedFigureId));
            }

            var processor = new BoardProcessor(new Board(figures), logs);
            var result = processor.CalculateBoard().Figures.Select((x) => new FigureDTO(x.FigureType.Id, x.Color.Id, x.Coordinate, x.MoveOptions));

            return new GetBoardResponseDTO { Figures = result };
        }

        public IEnumerable<Log> GetLogs(int gameId)
        {
            var logs = new List<Log>();
            var game = _context.Game.AsNoTracking()
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.StartColumn)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.StartRow)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.EndColumn)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.EndRow)
                .Include(game => game.NotationLogs)
                    .ThenInclude(log => log.PromotedFigure)
                .Single(x => x.Id == gameId);

            foreach (var log in game.NotationLogs)
            {
                var startColumn = Enumeration.FromValue<Column>(log.StartColumn.Id);
                var startRow = Enumeration.FromValue<Row>(log.StartRow.Id);
                var endColumn = Enumeration.FromValue<Column>(log.EndColumn.Id);
                var endRow = Enumeration.FromValue<Row>(log.EndRow.Id);

                logs.Add(new Log(new Coordinate(startColumn, startRow).ToString(), new Coordinate(endColumn, endRow).ToString(), log.Castle, log.EnPassant, log.PromotedFigureId));
            }
            return logs;
        }
    }
}
