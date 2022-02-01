using System.Collections.Generic;

namespace ChessGame.Logic
{
    public interface IActionStrategy
    {
        IBoard InputBoard { get; }
        IBoard OutputBoard { get; }
        Color CurrentPlayer { get; }
        IFigure CurrentlySelectedFigure { get; }
        Log GeneratedLog { get; }
        GameState GeneratedState { get; }
        void SelectFigure(Coordinate startPoint);
        void PrimaryCheck(Coordinate endPoint);
        void Execute(Coordinate endPoint);
        void EndOfTheGameCheck();
    }
}
