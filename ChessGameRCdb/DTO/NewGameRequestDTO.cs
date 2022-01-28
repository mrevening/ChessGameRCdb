using System.Collections.Generic;

namespace ChessGame.DTO
{
    public class NewGameRequestDTO
    {
        public string HostId { get; set; }
        public string HostName { get; set; }
        public string HostToken { get; set; }
        public int HostColor { get; set; }
    }
}
