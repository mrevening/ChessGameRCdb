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
        public async Task<GetBoardResponseDTO> GetBoard(int gameId)
        {
            var board = _boardQuery.GetBoard(gameId);
            await _moveHub.Clients.Group(gameId.ToString()).ReceiveMove(new MoveMessage() { Board = board.Figures });
            return board;
        }

        [HttpPost]
        public bool SaveMove([FromBody] MoveDTO move)
        {
            _boardCommand.CreateLog(move);
            return true;
        }
    }
}
