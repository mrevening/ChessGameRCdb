using ChessGame.Logic;
using System.Linq;
using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class MoveOptionDTO
    {
        public ActionType Action { get; set; }
        public LogDTO Log { get; set; }

        public MoveOptionDTO() {  }
        public MoveOptionDTO(MoveOption m) 
        {
            Action = m.Action;
            Log = new LogDTO(m.Log);
        }
    }
}
