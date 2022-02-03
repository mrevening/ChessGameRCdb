namespace ChessGame.Logic
{
    public class BoardValidator
    {
        private Log previousLog;
        public void ValidateLogs(Board b, Log log)
        {
            if (previousLog != null && b.GetFigure(log.StartPoint).Color == b.GetFigure(previousLog.EndPoint).Color) throw new IllegalMoveException("A player cannot move figure twice in one turn.");
            previousLog = log;
        }
    }
}
