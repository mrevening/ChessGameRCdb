using Microsoft.AspNetCore.SignalR;

namespace ChessGame.HubMove
{
    public class MoveHub : Hub<IMoveClient>
    { }
}