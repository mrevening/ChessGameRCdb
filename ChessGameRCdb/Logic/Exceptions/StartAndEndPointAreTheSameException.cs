﻿using System;

namespace ChessGame.Logic
{
    public class StartAndEndPointAreTheSameException : Exception
    {
        public StartAndEndPointAreTheSameException() { }
        public StartAndEndPointAreTheSameException(string message) : base(message) { }
        public StartAndEndPointAreTheSameException(string message, Exception innerExcepetion) : base(message, innerExcepetion) { }
    }
}
