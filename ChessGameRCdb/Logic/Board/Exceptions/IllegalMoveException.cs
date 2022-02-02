using System;

namespace ChessGame.Logic
{
    public class IllegalMoveException : Exception
    {
        public IllegalMoveException() { }
        public IllegalMoveException(string message) : base(message) { }
        public IllegalMoveException(string message, Exception innerExcepetion) : base(message, innerExcepetion) { }
    }
}
