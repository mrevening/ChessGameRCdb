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
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IHubContext<MoveHub, IMoveClient> _moveHub;
        private readonly IBoardQuery _boardQuery;
        private readonly IBoardCommand _boardCommand;

        public BoardController(ILogger<BoardController> logger, IHubContext<MoveHub, IMoveClient> moveHub, IBoardQuery boardQuery, IBoardCommand boardCommand)
        {
            _logger = logger;
            _moveHub = moveHub;
            _boardQuery = boardQuery;
            _boardCommand = boardCommand;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IEnumerable<FigureDTO>> GetBoard(int gid)
        {
            var board = _boardQuery.GetBoard(gid);
            await _moveHub.Clients.All.ReceiveMove(new MoveMessage() { Board = board });
            return _boardQuery.GetBoard(gid);
        }

        [HttpPost]
        [Route("{name}")]
        public bool SaveMove([FromBody] MoveDTO move)
        {
            _boardCommand.CreateLog(move);
            return true;
        }
    }
}
