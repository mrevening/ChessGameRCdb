using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class MoveOptionDTO
    {
        public int Action { get; set; }
        public LogDTO Log { get; set; }
        
        public MoveOptionDTO(MoveOption m) 
        {
            Action = m.Action.Id;
            Log = new LogDTO(m.Log);
        }
    }
}
