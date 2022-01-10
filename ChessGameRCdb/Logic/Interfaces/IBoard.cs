using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;
using System.Collections.Generic;

namespace ChessGame.Logic.Interfaces
{
    public interface IBoard
    {
        List<MoveLog> Logs { get; }
        List<IFigure> Figures { get; }
        bool IsPlayersFigure(Player currentPlayer, Coordinate position);
        bool IsEnemysFigure(Player currentPlayer, Coordinate position);
        bool IsEmptyField(Coordinate position);
        IFigure? GetFigure(Coordinate position);
        void MoveFigure(IFigure figure, Coordinate endPoint);
    }
}
