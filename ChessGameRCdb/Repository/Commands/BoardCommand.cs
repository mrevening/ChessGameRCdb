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
        public void CreateLog(SaveLogDTO log)
        {
            _boardcontext.Add(new NotationLog()
            {
                GameId = log.GameId,
                StartColumnId = log.ColumnStart,
                StartRowId = log.RowStart,
                EndColumnId = log.ColumnEnd,
                EndRowId = log.RowEnd
            });
            _boardcontext.SaveChanges();
        }
    }
}
