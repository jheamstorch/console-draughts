using Board.Exceptions;

namespace Board
{
    class Board
    {
        // An integer containing the width of the board.
        public readonly int Width;
        // An integer containing the height of the board.
        public readonly int Height;
        // An array containing all Pieces of the board.
        public Piece[,] Pieces;

        //
        // Summary:
        //     The main board's constructor.
        //
        // Parameters:
        //   width:
        //     The width of the new board.
        //
        //   height:
        //     The height of the new board.
        //
        // Exceptions:
        //   TooBigBoardException:
        //     Throw when the width or height of the board is greater than 26.
        public Board(int width, int height)
        {
            //
            // Verifies if the board is too big.
            if (width > 26 || height > 26)
            {
                throw new TooBigBoardException("The width or height of the board is greater than 26. Please create a smaller board.");
            }
            
            //
            // Sets both width and height.
            Width = width;
            Height = height;

            //
            // Sets the number of pieces on the board based on the width and height of the board.
            Pieces = new Piece[Width, Height];
        }

        //
        // Summary:
        //     Place the piece in a position on the board.
        //
        // Parameters:
        //   piece:
        //     The piece to be placed.
        //
        //   position:
        //     The position of the array where the piece will be placed.
        public void PlacePiece(Piece piece, TwoDimensionsArrayPosition position)
        {
            Pieces[position.Row, position.Column] = piece;
        }
    }
}
