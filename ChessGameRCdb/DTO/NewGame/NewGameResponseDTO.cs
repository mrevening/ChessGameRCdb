namespace ChessGame.DTO
{
    public class NewGameResponseDTO
    {
        public int GameId { get; set; }
        public string HostId { get; set; }
        public string HostName { get; set; }
        public string HostToken { get; set; }
        public int HostColor { get; set; }
    }
}
