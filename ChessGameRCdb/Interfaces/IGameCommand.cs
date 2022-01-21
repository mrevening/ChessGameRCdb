using ChessGame.DTO;

namespace ChessGame.Interface
{
    public interface IGameCommand
    {
        NewGameResponseDTO CreateNewGame(NewGameRequestDTO move);
    }
}
