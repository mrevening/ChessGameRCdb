using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using ChessGame.Hub;
using ChessGame.DTO;
using ChessGame.Interface;

namespace ChessGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;
        private readonly IBoardQuery _boardQuery;
        private readonly IBoardCommand _boardCommand;

        public BoardController(ILogger<BoardController> logger, IHubContext<ChatHub, IChatClient> chatHub, IBoardQuery boardQuery, IBoardCommand boardCommand)
        {
            _logger = logger;
            _chatHub = chatHub;
            _boardQuery = boardQuery;
            _boardCommand = boardCommand;
        }

        [HttpGet]
        [Route("{name}")]
        public IEnumerable<FigureDTO> GetCurrentGameStatus()
        {
            return _boardQuery.GetBoard(1);
        }

        [HttpPost]
        public void SaveLog(MoveDTO move)
        {
            _boardCommand.CreateLog(move);
        }
    }
}
