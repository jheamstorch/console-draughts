using System;

namespace Draughts.Exceptions
{
    //
    // Summary:
    //     Indicates an invalid position requested by the player. Invalid like
    //     a postion that tries to break the rules of the game.
    class InvalidPositionException : ApplicationException
    {
        public InvalidPositionException(string message) : base(message)
        {
        }
    }
}
