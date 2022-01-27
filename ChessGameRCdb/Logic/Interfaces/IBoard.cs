using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IBoard
    {
        Color CurrentPlayerColor { get; }
        List<Log> Logs { get; }
        List<IFigure> Figures { get; }
        bool IsPlayersFigure(Color currentPlayer, Coordinate position);
        bool IsEnemysFigure(Color currentPlayer, Coordinate position);
        bool IsEmptyField(Coordinate position);
        IFigure? GetFigure(Coordinate position);
        void MoveFigure(IFigure figure, Coordinate endPoint);
    }
}
