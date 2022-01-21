using ChessGame.DbModels;
using ChessGame.DTO;
using ChessGame.Infrastructure;
using ChessGame.Interface;

namespace ChessGame.Command
{
    public class GameCommand : IGameCommand
    {
        private readonly BoardDbContext _boardcontext;

        public GameCommand(BoardDbContext boardContext)
        {
            _boardcontext = boardContext;
        }
        public NewGameResponseDTO CreateNewGame(NewGameRequestDTO move)
        {
            var newGame = new Game()
            {
                StartPlayerId = 1,
                BoardConfigurationId = 1
            };

            _boardcontext.Game.Add(newGame);

            _boardcontext.SaveChanges();
            return new NewGameResponseDTO() { GameId = newGame.Id };
        }
    }
}
