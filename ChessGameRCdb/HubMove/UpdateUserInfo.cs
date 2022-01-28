using ChessGame.DTO;
using System.Collections.Generic;

namespace ChessGame.HubMove
{
    public class UpdateUserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}