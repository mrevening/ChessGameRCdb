using System.Threading.Tasks;

namespace ChessGame.Hub
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}