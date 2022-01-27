using System.Collections.Generic;

namespace ChessGame.DbModels
{
    public class Game
    {
        public int Id { get; set; }
        public string HostId { get; set; }
        public string GuestId { get; set; }
        public int HostColorId { get; set; }
        public int BoardConfigurationId { get; set; }
        public virtual Color HostColor { get; set; }
        public virtual BoardConfiguration BoardConfiguration { get; set; }
        public virtual IEnumerable<NotationLog> NotationLogs { get; set; }
    }
}
