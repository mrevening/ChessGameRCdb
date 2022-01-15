using ChessGame.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChessGame.Infrastructure
{
    public class BoardDbContext : DbContext
    {
        public BoardDbContext(DbContextOptions<BoardDbContext> options) : base(options) { }

        public DbSet<Game> Game { get; set; }
        //public DbSet<BoardConfiguration> BoardConfiguration { get; set; }
        //public DbSet<BoardConfigurationCode> BoardConfigurationCode { get; set; }
        //public DbSet<NotationLog> NotationLog { get; set; }
    }
}