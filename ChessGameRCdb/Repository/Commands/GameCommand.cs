using ChessGame.DbModels;
using ChessGame.DTO;
using ChessGame.Infrastructure;
using ChessGame.Interface;
using ChessGame.Logic;

namespace ChessGame.Command
{
    public class GameCommand : IGameCommand
    {
        private readonly BoardDbContext _boardcontext;

        public GameCommand(BoardDbContext boardContext)
        {
            _boardcontext = boardContext;
        }
        public NewGameResponseDTO CreateNewGame(NewGameRequestDTO request)
        {
            var newGame = new Game()
            {
                HostId = request.HostId,
                HostColorId = request.HostColor,
                BoardConfigurationId = 1
            };

            _boardcontext.Game.Add(newGame);

            _boardcontext.SaveChanges();
            return new NewGameResponseDTO() { GameId = newGame.Id };
        }
        public JoinGameResponseDTO JoinGame(JoinGameRequestDTO request)
        {
            var game = _boardcontext.Game.Find(request.GameId);
            game.GuestId = request.GuestId;
             _boardcontext.SaveChanges();

            return new JoinGameResponseDTO() { GameId = request.GameId, GuestId = request.GuestId, HostId = game.HostId, HostColorId = game.HostColorId };
        }
    }
}
