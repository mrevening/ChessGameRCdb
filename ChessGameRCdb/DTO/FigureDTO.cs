using ChessGame.Logic.Definitions;
using System.Linq;
using System.Collections.Generic;

namespace ChessGameCoreRedux.DTO
{
    public class FigureDTO
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public int Player { get; set; }

        public string Square { get; set; }
        public IEnumerable<string> PossibleMoves { get; set; }

        public FigureDTO(int id, int type, int player, Coordinate square, IEnumerable<Coordinate> possibleMoves) 
        {
            Id = id;
            Type = type;
            Player = player;
            Square = square.ToString();
            PossibleMoves = possibleMoves.Select(x => x.ToString());
        }
    }
}
