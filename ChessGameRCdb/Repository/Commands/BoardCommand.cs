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
    }
}
