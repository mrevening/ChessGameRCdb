using ChessGame.Logic;
using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;
using ChessGame.Logic.Interfaces;
using ChessGame.Logic.Singletons;
using ChessGameCoreRedux.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessGameCoreRedux.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        //private readonly ApplicationDbContext _context;

        public BoardController(ILogger<BoardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<FigureDTO> GetStandardConfiguration()
        {
            var board = new Board(BoardSetup.GetInstance().GetStandardSetup());
            var dto = board.Figures.Select((x, i) => new FigureDTO(i, x.FigureType.Id, x.Player.Id, x.Coordinate, x.MoveOptions(board)));
            return dto;
        }

        [HttpGet]
        [Route("{name}")]
        public IEnumerable<FigureDTO> Move()
        {
            var board = new Board(BoardSetup.GetInstance().GetStandardSetup());
            var dto = board.Figures.Select((x, i) => new FigureDTO(i, x.FigureType.Id, x.Player.Id, x.Coordinate, x.MoveOptions(board)));
            return dto;
        }
    }
}
