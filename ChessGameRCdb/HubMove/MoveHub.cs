using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChessGame.HubMove
{
    public class MoveHub : Hub<IMoveClient>
    {
        public Task JoinRoom(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }
    }
}