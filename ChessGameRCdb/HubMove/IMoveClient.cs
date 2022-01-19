using System.Threading.Tasks;

namespace ChessGame.HubMove
{
    public interface IMoveClient
    {
        Task ReceiveMove(MoveMessage message);
    }
}