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
    public class MenuController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IHubContext<MoveHub, IMoveClient> _moveHub;
        private readonly IGameQuery _query;
        private readonly IGameCommand _command;

        public MenuController(ILogger<BoardController> logger, IHubContext<MoveHub, IMoveClient> moveHub, IGameQuery query, IGameCommand command)
        {
            _logger = logger;
            _query = query;
            _command = command;
            _moveHub = moveHub;
        }

        [HttpPost]
        public LoggedInResponseDTO LoggedIn([FromBody] LoggedInRequestDTO request)
        {
            return new LoggedInResponseDTO() { };
        }

        [HttpPost]
        public NewGameResponseDTO GetActiveGamesList([FromBody] NewGameRequestDTO move)
        {
            var result = _command.CreateNewGame(move);
            return result;
        }
    }
}
