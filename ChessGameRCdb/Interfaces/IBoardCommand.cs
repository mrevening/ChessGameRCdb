using ChessGame.DTO;

namespace ChessGame.Interface
{
    public interface IBoardCommand
    {
        void CreateLog(MoveDTO move);
        void CreateLog(int gameId, LogDTO log);
    }
}
