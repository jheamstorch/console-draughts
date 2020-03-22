using Board.Exceptions;

namespace Board
{
    class Board
    {
        //
        // An integer containing the width of the board
        public readonly int Width;
        //
        // An integer containing the height of the board
        public readonly int Height;
        //
        // An array containing all Pieces of the board
        public Piece[,] Pieces;

        public Board(int width, int height)
        {
            //
            // Verifies if the board is too big
            if (width > 26 || height > 26)
            {
                throw new TooBigBoardException("The width or height of the board is greater than 26. Please create a smaller board.");
            }
            
            //
            // Sets both width and height
            Width = width;
            Height = height;

            //
            // Sets the number of pieces on the board based on the width and height of the board
            Pieces = new Piece[Width, Height];
        }
    }
}
