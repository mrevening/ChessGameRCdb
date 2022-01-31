using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class FigureDTO
    {
        public int Type { get; set; }
        public int Color { get; set; }
        public string Square { get; set; }
        public IEnumerable<MoveOptionDTO> PossibleMoves { get; set; }

        public FigureDTO(int type, int player, Coordinate square, IEnumerable<MoveOption> possibleMoves) 
        {
            Type = type;
            Color = player;
            Square = square.ToString();
            PossibleMoves = possibleMoves.Select(x => new MoveOptionDTO(x));
        }
    }
}
