namespace ChessGame.DTO
{
    public class JoinGameResponseDTO
    {
        public int GameId { get; set; }
        public string GuestId { get; set; }
        public string GuestName { get; set; }
        public string GuestToken { get; set; }
        public string HostId { get; set; }
        public string HostName { get; set; }
        public string HostToken { get; set; }
        public int HostColorId { get; set; }
    }
}
