using System;

namespace Board.Exceptions
{
    //
    // Summary:
    //     This prevents the programmer from trying to create an unsupported
    //     board (Width greater than 26 or height greater than 99.)
    class TooBigBoardException : ApplicationException
    {
        public TooBigBoardException(string message) : base(message)
        {
        }
    }
}
