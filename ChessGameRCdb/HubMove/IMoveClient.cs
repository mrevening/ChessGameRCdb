using System.Threading.Tasks;

namespace ChessGame.HubMove
{
    public interface IMoveClient
    {
        Task UpdateBoard(UpdateBoardDTO message);
        Task JoinRoom(string roomName);
        Task UpdateGuestInfo(UpdateUserInfo message);
    }
}