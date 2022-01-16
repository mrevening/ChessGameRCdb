namespace ChessGame.Logic
{
    public class ChessSession: IGame
    {
        public IBoard InputBoard { get; private set; }

        public ChessSession(IBoard board)
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
