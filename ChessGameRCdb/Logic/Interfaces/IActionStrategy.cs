using ChessGame.Logic;
using ChessGame.Logic;

namespace ChessGame.Logic
{
    public interface IActionStrategy
    {
        IBoard InputBoard { get; }
        IBoard OutputBoard { get; }
        Player CurrentPlayer { get; }
        IFigure CurrentlySelectedFigure { get; }
        MoveLog GeneratedLog { get; }
        GameState GeneratedState { get; }
        void SelectFigure(Coordinate startPoint);
        void PrimaryCheck(Coordinate endPoint);
        void DetermineMove(Coordinate startPoint);
        void Execute(Coordinate endPoint);
        void EndOfTheGameCheck();
    }
}
