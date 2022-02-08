using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IFigure
    {
        Color Color { get; }
        Coordinate Coordinate { get; }
        Diagonal Diagonal { get; }
        FigureType FigureType { get; }
        List<IActiveAction> MoveTypes { get; }
        List<IPassiveAttack> AttackTypes { get; }
        HashSet<MoveOption> MoveOptions { get; set; }
        HashSet<AttackOption> AttackOptions { get; set; }
        bool CannotBeMoved { get; set; }
        bool IsPlayersFigure(Color player, Coordinate endPoint);
        bool IsOpponentFigure(Color player, Coordinate endPoint);
        bool IsInPosition(Coordinate endPoint);
        void SetPosition(Coordinate endPoint);
    }
}
