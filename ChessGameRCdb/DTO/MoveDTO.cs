using ChessGame.Logic.Definitions;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class MoveDTO
    {
        public string GameId { get; set; }
        public string SquareFrom { get; set; }
        public string SquareTo { get; set; }

        public MoveDTO() 
        {
        }
    }
}
