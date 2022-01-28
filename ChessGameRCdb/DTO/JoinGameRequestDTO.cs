using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class JoinGameRequestDTO
    {
        public int GameId { get; set; }
        public string GuestId { get; set; }
        public string GuestName { get; set; }
        public string GuestToken { get; set; }
    }
}
