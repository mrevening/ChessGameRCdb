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
    [ApiController]
    [Route("api/[controller]")]
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
        [Route("{name}")]
        public NewGameResponseDTO CreateNewGame([FromBody] NewGameRequestDTO move)
        {
            var result = _command.CreateNewGame(move);
            return result;
        }
    }
}
