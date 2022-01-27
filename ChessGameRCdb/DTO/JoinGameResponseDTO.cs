namespace ChessGame.DTO
{
    public class JoinGameResponseDTO
    {
        public int GameId { get; set; }
        public string GuestId { get; set; }
        public string HostId { get; set; }
        public int HostColorId { get; set; }
    }
}
