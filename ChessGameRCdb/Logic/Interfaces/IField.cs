using ChessGame.Logic;

namespace ChessGame.Logic
{
    public interface IField
    {
        Column Column { get; }
        Row Row { get; }
        bool IsOccupied();
    }
}
