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
            _boardcontext.Add(new NotationLog()
            {
                GameId = move.GameId,
                StartColumnId = move.ColumnStart,
                StartRowId = move.RowStart,
                EndColumnId = move.ColumnEnd,
                EndRowId = move.RowEnd
            });
            _boardcontext.SaveChanges();
        }
        public void CreateLog(int gameId, LogDTO l)
        {
            var s = new Coordinate(l.Start);
            var e = new Coordinate(l.End);
            _boardcontext.Add(new NotationLog()
            {
                GameId = gameId,
                StartColumnId = s.Column.Id,
                StartRowId = s.Row.Id,
                EndColumnId = e.Column.Id,
                EndRowId = e.Row.Id
            });
            _boardcontext.SaveChanges();
        }
    }
}
