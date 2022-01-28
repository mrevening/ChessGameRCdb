using System.Collections.Generic;

namespace ChessGame.DbModels
{
    public class Game
    {
        public int Id { get; set; }
        public string HostId { get; set; }
        public string HostName { get; set; }
        public string HostToken { get; set; }
        public int HostColorId { get; set; }
        public string GuestId { get; set; }
        public string GuestName { get; set; }
        public string GuestToken { get; set; }
        public int BoardConfigurationId { get; set; }
        public virtual Color HostColor { get; set; }
        public virtual BoardConfiguration BoardConfiguration { get; set; }
        public virtual IEnumerable<NotationLog> NotationLogs { get; set; }
    }
}
