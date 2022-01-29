using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class MoveOptionDTO
    {
        public string Square { get; set; }
        public IEnumerable<int> ActionTypes { get; set; }

        public MoveOptionDTO(MoveOption moveOption) 
        {
            Square = moveOption.Coordinate.ToString();
            ActionTypes = moveOption.Actions.Select(x => x.Id);
        }
    }
}
