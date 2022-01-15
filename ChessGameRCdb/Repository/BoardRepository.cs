using ChessGame.DbModels;
using ChessGame.Infrastructure;
using ChessGame.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ChessGame.Repository
{
    public class BoardRepository: IBoardRepository
    {
        private readonly BoardDbContext _context;

        public BoardRepository(BoardDbContext boardContext)
        {
            _context = boardContext;
        }
        public Game GetGame(int id)
        {
            return _context.Game.FirstOrDefault(x => x.Id == id);
        }
    }
}
