using System.Collections.Generic;

namespace Board
{
    //
    // Summary:
    //     A generic piece.
    abstract class Piece
    {
        //
        // The symbol of the piece
        private readonly string _symbol;
        //
        // The piece's board.
        public readonly Board Board;
        //
        // Contains the Team of the piece
        public readonly Team Team;
        //
        // Contains the row and column of the piece's position in the board
        public BoardPosition BoardPosition { get; set; }

        //
        // Summary:
        //     The base contructor for this abstract's children.
        //
        // Parameters:
        //   symbol:
        //     The visual representation of piece.
        //
        //   boardPosition:
        //     The position of piece in the board.
        //
        //   board:
        //     The board on which the piece belongs.
        //
        //   team:
        //     The team of piece.
        protected Piece(string symbol, BoardPosition boardPosition, Board board, Team team)
        {
            _symbol = symbol;

            BoardPosition = boardPosition;

            Board = board;

            Team = team;
        }

        //
        // Summary:
        //     Checks for the possble targets of piece.
        //
        // Returns:
        //     An array of bool with the same size of the Board.Board._pieces marking ennemy pieces threatened or not by the current piece.
        public abstract bool[,] PossibleTargets();

        public override string ToString()
        {
            return _symbol;
        }
    }
}
