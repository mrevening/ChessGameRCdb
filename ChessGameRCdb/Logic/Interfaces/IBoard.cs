using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IBoard
    {
        List<Log> Logs { get; }
        List<IFigure> Figures { get; }
        bool IsPlayersFigure(Player currentPlayer, Coordinate position);
        bool IsEnemysFigure(Player currentPlayer, Coordinate position);
        bool IsEmptyField(Coordinate position);
        IFigure? GetFigure(Coordinate position);
        void MoveFigure(IFigure figure, Coordinate endPoint);
    }
}
