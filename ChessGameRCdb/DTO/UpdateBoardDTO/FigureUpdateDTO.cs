using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class FigureUpdateDTO
    {
        public int Type { get; set; }
        public int Color { get; set; }
        public string Square { get; set; }

        public FigureUpdateDTO(int type, int player, Coordinate square) 
        {
            Type = type;
            Color = player;
            Square = square.ToString();
        }
    }
}
