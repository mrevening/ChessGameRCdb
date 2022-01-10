using ChessGame.Logic.Enums;

namespace ChessGame.Logic.Interfaces
{
    public interface IField
    {
        Column Column { get; }
        Row Row { get; }
        bool IsOccupied();
    }
}
