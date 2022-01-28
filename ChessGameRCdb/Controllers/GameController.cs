using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using ChessGame.DTO;
using ChessGame.Interface;
using ChessGame.HubMove;
using System.Threading.Tasks;

namespace ChessGame.Controllers
{
    public class GameController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IHubContext<MoveHub, IMoveClient> _moveHub;
        private readonly IGameQuery _query;
        private readonly IGameCommand _command;

        public GameController(ILogger<BoardController> logger, IHubContext<MoveHub, IMoveClient> moveHub, IGameQuery query, IGameCommand command)
        {
            _logger = logger;
            _query = query;
            _command = command;
            _moveHub = moveHub;
        }

        [HttpPost]
        public NewGameResponseDTO CreateNewGame([FromBody] NewGameRequestDTO request)
        {
            var result = _command.CreateNewGame(request);
            return result;
        }
        [HttpPost]
        public JoinGameResponseDTO JoinGame([FromBody] JoinGameRequestDTO request)
        {
            var result = _command.JoinGame(request);
            _moveHub.Clients.Group(result.GameId.ToString()).UpdateGuestInfo(new UpdateUserInfo() { Id = result.GuestId, Name = result.GuestName, Token = result.GuestToken });
            return result;
        }
    }
}
