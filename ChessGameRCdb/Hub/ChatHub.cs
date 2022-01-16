using Microsoft.AspNetCore.SignalR;

namespace ChessGame.Hub
{
    public class ChatHub : Hub<IChatClient>
    { }
}