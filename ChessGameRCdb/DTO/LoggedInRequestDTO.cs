using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class LoggedInRequestDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}