using System.Collections.Generic;

namespace ChessGame.DbModels
{
    public class Game
    {
        public int Id { get; set; }
        public int StartPlayerId { get; set; }
        public int BoardConfigurationId { get; set; }
        public virtual Player StartPlayer { get; set; }
        public virtual BoardConfiguration BoardConfiguration { get; set; }
        public virtual IEnumerable<NotationLog> NotationLogs { get; set; }
    }
}
