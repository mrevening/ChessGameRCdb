using ChessGame.DbModels;
using ChessGame.DTO;
using ChessGame.Infrastructure;
using ChessGame.Interface;

namespace ChessGame.Command
{
    public class GameQuery : IGameQuery
    {
        private readonly BoardDbContext _boardcontext;

        public GameQuery(BoardDbContext boardContext)
        {
            _boardcontext = boardContext;
        }
        public Game GetGame(int id)
        {

            var game = _boardcontext.Game.Find(id);

            return game;
        }
    }
}
