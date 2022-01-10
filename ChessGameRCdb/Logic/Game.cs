using ChessGame.Logic.Definitions;
using ChessGame.Logic.Enums;
using ChessGame.Logic.Implementations;
using ChessGame.Logic.Interfaces;

namespace ChessGame.Logic
{
    public class Game: IGame
    {
        public IBoard InputBoard { get; private set; }

        public Game(IBoard board)
        {
            InputBoard = board;
        }

        public IGameStatus PlayersAction(Player player, Coordinate startPoint, Coordinate endPoint)
        {
            var action = GetAction(player);
            action.SelectFigure(startPoint);
            action.PrimaryCheck(endPoint);
            action.DetermineMove(endPoint);
            action.Execute(endPoint);
            action.EndOfTheGameCheck();

            return new GameStatus(action.OutputBoard, action.GeneratedLog, action.GeneratedState);
        }

        private IActionStrategy GetAction(Player player)
        {
            if (player == Player.White) return new MoveWhiteFigure(InputBoard);
            else return new MoveBlackFigure(InputBoard);
        }
    }
}
