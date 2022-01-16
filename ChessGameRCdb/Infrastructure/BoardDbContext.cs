using ChessGame.DbModels;
using Microsoft.EntityFrameworkCore;

namespace ChessGame.Infrastructure
{
    public class BoardDbContext : DbContext
    {
        public BoardDbContext(DbContextOptions<BoardDbContext> options) : base(options) { }

        public DbSet<Game> Game { get; set; }
        public DbSet<NotationLog> NotationLog { get; set; }
    }
}