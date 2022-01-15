using ChessGame.DbModels;

namespace ChessGame.Interface
{
    public interface IBoardRepository
    {
        public Game GetGame(int id);
    }
}
