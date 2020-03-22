using System;

namespace Board.Exceptions
{
    class TooBigBoardException : ApplicationException
    {
        public TooBigBoardException(string message) : base(message)
        {
        }
    }
}
