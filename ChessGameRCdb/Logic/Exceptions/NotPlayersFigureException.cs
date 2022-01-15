using System;

namespace ChessGame.Logic
{
    public class NotPlayersFigureException : Exception
    {
        public NotPlayersFigureException() { }
        public NotPlayersFigureException(string message) : base(message) { }
        public NotPlayersFigureException(string message, Exception innerExcepetion) : base(message, innerExcepetion) { }
    }
}
