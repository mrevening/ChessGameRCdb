using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using ChessGame.DTO;
using ChessGame.Interface;
using ChessGame.HubMove;
using System.Threading.Tasks;
using ChessGame.Logic;
using System.Linq;
using System;

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
            await _moveHub.Clients.Group(gameId.ToString()).UpdateBoard(new UpdateBoardDTO() { Board = board.Figures });
            return board;
        }

        [HttpGet]
        public async Task UpdateBoard(UpdateBoardRequestDTO r)
        {
            _boardCommand.CreateLog(r.Log);
            var previousBoard = r.Figures.Select(X =>
            {
                var figureType = Enumeration.FromValue<FigureType>(X.Type);
                var color = Enumeration.FromValue<Color>(X.Color);
                var typeName = typeof(IFigure).Namespace + "." + figureType.ToString();
                var figure = (IFigure)Activator.CreateInstance(Type.GetType(typeName), new object[] { color, new Coordinate(X.Square) });
                return figure;
            });
            var log = new Log(new Coordinate(r.Log.ColumnStart, r.Log.ColumnEnd), new Coordinate(r.Log.ColumnEnd, r.Log.ColumnEnd));
            var newBoard = new BoardProcessor(new Board(previousBoard)).CalculateBoard(new List<Log>() { log });
            var dtoBoard = newBoard.Figures.Select((x) => new FigureDTO(x.FigureType.Id, x.Color.Id, x.Coordinate, x.MoveOptions));
            await _moveHub.Clients.Group(r.GameId.ToString()).UpdateBoard(new UpdateBoardDTO() { Board = dtoBoard });
        }

        //[HttpPost]
        //public bool SaveMove([FromBody] MoveDTO move)
        //{
        //    _boardCommand.CreateLog(move);
        //    return true;
        //}
    }
}
