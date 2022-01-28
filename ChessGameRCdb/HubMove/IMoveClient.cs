using System.Threading.Tasks;

namespace ChessGame.HubMove
{
    public interface IMoveClient
    {
        Task ReceiveMove(MoveMessage message);
        Task JoinRoom(string roomName);
        Task UpdateGuestInfo(UpdateUserInfo message);
    }
}