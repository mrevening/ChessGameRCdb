using System;

namespace ChessGame.Logic
{
    public class BlockedMoveException : Exception
    {
        public BlockedMoveException() { }
        public BlockedMoveException(string message) : base(message) { }
        public BlockedMoveException(string message, Exception innerExcepetion) : base(message, innerExcepetion) { }
    }
}
