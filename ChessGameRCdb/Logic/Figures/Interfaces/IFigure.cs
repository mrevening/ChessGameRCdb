using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IFigure
    {
        Color Color { get; }
        Coordinate Coordinate { get; }
        FigureType FigureType { get; }
        List<IMove> MoveTypes { get; }
        List<MoveOption> MoveOptions { get; set; }
        bool IsPlayersFigure(Color player, Coordinate endPoint);
        bool IsEnemysFigure(Color player, Coordinate endPoint);
        bool IsInPosition(Coordinate endPoint);
        void SetPosition(Coordinate endPoint);
    }
}
