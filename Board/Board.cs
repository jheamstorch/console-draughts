using static Board.BoardPosition;
using Board.Exceptions;

namespace Board
{
    //
    // Summary:
    //     This class represents a generic game board with it own width, height
    //     and positions with pieces.
    //
    // Exceptions:
    //   T:Board.Exception.TooBigBoardException:
    //     This prevents the programmer from trying to create an unsupported
    //     board (Width greater than 26 or height greater than 99.)
    class Board
    {
        //
        // An integer containing the width of the board.
        public readonly int Width;
        //
        // An integer containing the height of the board.
        public readonly int Height;
        //
        // An array containing all Pieces of the board.
        private readonly Piece[,] _pieces;

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
        //   T:Board.Exceptions.TooBigBoardException:
        //     Throw when the width or height of the board is greater than 26.
        public Board(int width, int height)
        {
            // Verifies if the board is too big.
            if (width > 26 || height > 26)
            {
                throw new TooBigBoardException("The board's width is greater than 26 or the board's height is greater than 99. Please create a smaller board.");
            }

            // Sets both width and height of the board.
            Width = width;
            Height = height;

            // Sets the number of pieces on the board based on the width and height of the board.
            _pieces = new Piece[Width, Height];
        }

        //
        // Summary:
        //     Return the piece in the positon informed.
        //
        // Parameters:    
        //   position:
        //     The BoardPosition where the piece should be.
        //
        // Returns:
        //     The piece in the position; otherwise returns null.
        public Piece Pieces(BoardPosition position)
        {
            return _pieces[FromBoardRowToArrayRow(position.Row, Height), FromBoardColumnToArrayColumn(position.Column)];
        }

        //
        // Summary:
        //     Return the piece in the positon informed.
        //
        // Parameters:    
        //   position:
        //     The TwoDimensionsArrayPosition where the piece should be.
        //
        // Returns:
        //     The piece in the position; otherwise returns null.
        public Piece Pieces(TwoDimensionsArrayPosition position)
        {
            return _pieces[position.Row, position.Column];
        }

        //
        // Summary:
        //     Return the piece in the positon informed.
        //
        // Parameters:    
        //   arrRow:
        //     The array row.
        //
        //   arrColumn:
        //     The array column.
        //
        // Returns:
        //     The piece in the position; otherwise returns null.
        public Piece Pieces(int arrRow, int arrColumn)
        {
            return _pieces[arrRow, arrColumn];
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
        //     The position of the board where the piece will be placed.
        public void PlacePiece(Piece piece, BoardPosition position)
        {
            _pieces[FromBoardRowToArrayRow(position.Row, Height), FromBoardColumnToArrayColumn(position.Column)] = piece;
            piece.BoardPosition = position;
        }

        //
        // Summary:
        //     Take the piece removing by it from the board.
        // 
        // Parameters:
        //   position:
        //     The position of the board where the piece is.
        //
        // Returns:
        //     The piece taked.
        public Piece TakePiece(BoardPosition position)
        {
            Piece piece = Pieces(position);
            _pieces[FromBoardRowToArrayRow(position.Row, Height), FromBoardColumnToArrayColumn(position.Column)] = null;
            piece.BoardPosition = null;

            return piece;
        }

        //
        // Summary:
        //     Take the piece removing by it from the board.
        // 
        // Parameters:
        //   position:
        //     The position of the array where the piece is.
        //
        // Returns:
        //     The piece taked.
        public Piece TakePiece(TwoDimensionsArrayPosition position)
        {
            Piece piece = Pieces(position);
            _pieces[position.Row, position.Column] = null;
            piece.BoardPosition = null;

            return piece;
        }
    }
}
