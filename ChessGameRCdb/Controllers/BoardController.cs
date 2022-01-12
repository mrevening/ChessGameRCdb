using ChessGame.Logic;
using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;
using ChessGame.Logic.Interfaces;
using ChessGame.Logic.Singletons;
using ChessGame.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessGame.Infrastructure;

namespace ChessGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly BoardDbContext _context;

        public BoardController(ILogger<BoardController> logger, BoardDbContext boardContext)
        {
            _logger = logger;
            _context = boardContext;
        }

        [HttpGet]
        [Route("{name}")]
        public IEnumerable<FigureDTO> GetStandardConfiguration()
        {

            _context.BoardConfiguration.Add(new DbModels.BoardConfiguration());
            _context.SaveChanges();

            var b = _context.BoardConfiguration.FirstOrDefault();
   


            var board = new Board(BoardSetup.GetInstance().GetStandardSetup());
            var dto = board.Figures.Select((x, i) => new FigureDTO(i, x.FigureType.Id, x.Player.Id, x.Coordinate, x.MoveOptions(board)));
            return dto;
        }

        //[HttpGet]
        //public void GetLog()
        //{
        //    var log = _context.Logs.FirstOrDefault(x => x.Id == "1");
        //}

        //[HttpGet]
        //[Route("{name}")]
        //public IEnumerable<FigureDTO> Move()
        //{
        //    var board = new Board(BoardSetup.GetInstance().GetStandardSetup());
        //    var dto = board.Figures.Select((x, i) => new FigureDTO(i, x.FigureType.Id, x.Player.Id, x.Coordinate, x.MoveOptions(board)));
        //    return dto;
        //}
    }
}
