using System;

namespace ChessGame.Logic.Exceptions
{
    public class BlockedMoveException : Exception
    {
        public BlockedMoveException() { }
        public BlockedMoveException(string message) : base(message) { }
        public BlockedMoveException(string message, Exception innerExcepetion) : base(message, innerExcepetion) { }
    }
}
