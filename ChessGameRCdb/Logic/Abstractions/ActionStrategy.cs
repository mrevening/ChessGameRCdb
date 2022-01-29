using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ChessGame.Logic
{
    public abstract class ActionStrategy : IActionStrategy
    {
        public abstract Color CurrentPlayer { get; }
        public abstract Direction Direction { get; }
        public IBoard InputBoard { get; private set; }
        public IBoard OutputBoard { get; private set; }
        public IFigure CurrentlySelectedFigure { get; private set; }
        public Log GeneratedLog { get; }
        public GameState GeneratedState { get; set; }

        public ActionStrategy(IBoard board)
        {
            InputBoard = board;
            InputBoard.Figures.ForEach(x => x.MoveTypes.ForEach(y =>  x.MoveOptions.AddRange(y.GetMoveOptions(InputBoard, x, Direction))));
        }

        public void SelectFigure(Coordinate startPoint)
        {
            if (!InputBoard.IsPlayersFigure(CurrentPlayer, startPoint)) throw new NotPlayersFigureException();
            CurrentlySelectedFigure = InputBoard.GetFigure(startPoint);
        }
        public void PrimaryCheck(Coordinate endPoint)
        {
            if (CurrentlySelectedFigure.Coordinate == endPoint) throw new StartAndEndPointAreTheSameException();
        }
        public void DetermineMove(Coordinate endPoint)
        {
            CurrentlySelectedFigure.IsMoveAllowed(OutputBoard, endPoint);
        }
        public void Execute(Coordinate endPoint)
        {
            RewriteBoard();
            OutputBoard.MoveFigure(CurrentlySelectedFigure, endPoint);
        }
        public void EndOfTheGameCheck()
        {
            foreach (var endGameScenario in Enumeration.GetAll<EndOfGame>())
            {
                if (endGameScenario.VerifyScenario(OutputBoard)) GeneratedState = endGameScenario.Type;
            }
        }
        private void RewriteBoard()
        {
            OutputBoard = new Board(ImmutableList.CreateRange(InputBoard.Figures).ToImmutableList(), CurrentPlayer);
        }
    }
}
