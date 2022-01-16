using ChessGame.DbModels;
using ChessGame.DTO;
using ChessGame.Infrastructure;
using ChessGame.Interface;
using ChessGame.Logic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame.Command
{
    public class BoardCommand : IBoardCommand
    {
        private readonly BoardDbContext _boardcontext;

        public BoardCommand(BoardDbContext boardContext)
        {
            _boardcontext = boardContext;
        }
        public void CreateLog(MoveDTO move)
        {
            var startColumn = Enumeration.FromValue<Logic.Column>(move.ColumnStart);
            var startRow = Enumeration.FromValue<Logic.Row>(move.RowStart);
            var endColumn = Enumeration.FromValue<Logic.Column>(move.ColumnEnd);
            var endRow = Enumeration.FromValue<Logic.Row>(move.RowEnd);
            var complexMoves = new List<int>();

            var log = new Log(move.GameId, new Coordinate(startColumn, startRow), new Coordinate(endColumn, endRow), null);
            _boardcontext.Add(log);
        }
    }
}
