namespace ChessGame.Logic
{
    public class ChessSession: IGame
    {
        public IBoard InputBoard { get; private set; }

        public ChessSession(IBoard board)
        {
            InputBoard = board;
        }

        public IGameStatus PlayersAction(Color player, Coordinate startPoint, Coordinate endPoint)
        {
            var action = GetAction(player);
            action.SelectFigure(startPoint);
            action.PrimaryCheck(endPoint);
            action.DetermineMove(endPoint);
            action.Execute(endPoint);
            action.EndOfTheGameCheck();

            return new GameStatus(action.OutputBoard, action.GeneratedLog, action.GeneratedState);
        }

        private IActionStrategy GetAction(Color player)
        {
            if (player == Color.White) return new MoveWhiteFigure(InputBoard);
            else return new MoveBlackFigure(InputBoard);
        }
    }
}
