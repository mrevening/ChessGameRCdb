using ChessGame.Logic;
using ChessGame.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using ChessGame.Interface;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ChessGame.Hub;

namespace ChessGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IBoardRepository _boardRepository;
        private readonly BoardCreator _boardCreator;
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;

        public BoardController(ILogger<BoardController> logger, IBoardRepository boardRepository, IHubContext<ChatHub, IChatClient> chatHub)
        {
            _logger = logger;
            _boardRepository = boardRepository;
            _boardCreator = BoardCreator.GetInstance();
            _chatHub = chatHub;
        }

        [HttpGet]
        [Route("{name}")]
        public IEnumerable<FigureDTO> GetStandardConfiguration()//GetCurrentGameStatus
        {
            var game = _boardRepository.GetGame(1);
            var board = _boardCreator.CreateBoard(game);
            var dto = board.Figures.Select((x, i) => new FigureDTO(i, x.FigureType.Id, x.Player.Id, x.Coordinate, x.MoveOptions(board)));
            return dto;
        }

        //[HttpGet]
        //public void GetLog()
        //{
        //    var log = _context.Logs.FirstOrDefault(x => x.Id == "1");
        //}


        [HttpPost("messages")]
        public async Task Chat(ChatMessage message)
        {
            //var board = new Board(BoardSetup.GetInstance().GetStandardSetup());
            //var dto = board.Figures.Select((x, i) => new FigureDTO(i, x.FigureType.Id, x.Player.Id, x.Coordinate, x.MoveOptions(board)));

            await _chatHub.Clients.All.ReceiveMessage(message);
            //return dto;
        }

        //[HttpPost("messages")]
        //public async Task Move(ChatMessage message) 
        //{
        //    //var board = new Board(BoardSetup.GetInstance().GetStandardSetup());
        //    //var dto = board.Figures.Select((x, i) => new FigureDTO(i, x.FigureType.Id, x.Player.Id, x.Coordinate, x.MoveOptions(board)));

        //    await _chatHub.Clients.All.ReceiveMessage(message);
        //    //return dto;
        //}
    }
}
