using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IFigure
    {
        Color Color { get; }
        Coordinate Coordinate { get; }
        FigureType FigureType { get; }
        IEnumerable<IMove> PossibleMoves { get; }
        IEnumerable<Coordinate> MoveOptions(IBoard board);
        bool IsMoveAllowed(IBoard currentBoard, Coordinate endPoint);
        bool IsPlayersFigure(Color player, Coordinate endPoint);
        bool IsEnemysFigure(Color player, Coordinate endPoint);
        bool IsInPosition(Coordinate endPoint);
        void SetPosition(Coordinate endPoint);
    }
}
