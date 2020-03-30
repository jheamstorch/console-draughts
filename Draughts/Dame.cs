using Board;

namespace Draughts
{
    //
    // Summary:
    //     Represents a Dame in a Draughts game.
    class Dame : Piece
    {
        //
        // Summary:
        //     The basic contructor of the Dame that only pass its own the
        //     parameters to its own superclass.
        //
        // Parameters:
        //   boardPosition:
        //     The position of this piece in the board.
        // 
        //   board:
        //     The board on which the piece belongs.
        //
        //   team:
        //     The team of the piece.
        public Dame(BoardPosition boardPosition, Board.Board board, Team team) : base("D", boardPosition, board, team)
        {
        }

        //
        // Summary:
        //     Create an array with the movements actually avaliable to the Dame.
        //
        // Returns:
        //     An array of booleans with the same size of the board where the
        //     positions contain a true value if it is a possible movement;
        //     otherwise it contains false.
        public override bool[,] PossibleTargets()
        {
            // 4-1
            // -D-
            // 3-2

            bool[,] possibleTargets = new bool[Board.Height, Board.Width];
            TwoDimensionsArrayPosition arrPos = BoardPosition.ToArrayPosition(Board.Height);

            // NE (1)
            if ((arrPos.Row - 1) >= 0 && (arrPos.Column + 1) < Board.Width)
            {
                if (Board.Pieces(arrPos.Row - 1, arrPos.Column + 1) == null)
                {
                    possibleTargets[arrPos.Row - 1, arrPos.Column + 1] = true;
                }
                else if (Board.Pieces(arrPos.Row - 1, arrPos.Column + 1).Team != Team)
                {
                    if (((arrPos.Row - 2) >= 0 && (arrPos.Column + 2) < Board.Width) && Board.Pieces(arrPos.Row - 2, arrPos.Column + 2) == null)
                    {
                        possibleTargets[arrPos.Row - 2, arrPos.Column + 2] = true;
                    }
                }
            }

            // SE (2)
            if ((arrPos.Row + 1) < Board.Height && (arrPos.Column + 1) < Board.Width)
            {
                if (Board.Pieces(arrPos.Row + 1, arrPos.Column + 1) == null)
                {
                    possibleTargets[arrPos.Row + 1, arrPos.Column + 1] = true;
                }
                else if (Board.Pieces(arrPos.Row + 1, arrPos.Column + 1).Team != Team)
                {
                    if ((arrPos.Row + 2) < Board.Height && (arrPos.Column + 2) < Board.Width && Board.Pieces(arrPos.Row + 2, arrPos.Column + 2) == null)
                    {
                        possibleTargets[arrPos.Row + 2, arrPos.Column + 2] = true;
                    }
                }
            }

            // SW (3)
            if ((arrPos.Row + 1) < Board.Height && (arrPos.Column - 1) >= 0)
            {
                if (Board.Pieces(arrPos.Row + 1, arrPos.Column - 1) == null)
                {
                    possibleTargets[arrPos.Row + 1, arrPos.Column - 1] = true;
                }
                else if (Board.Pieces(arrPos.Row + 1, arrPos.Column - 1).Team != Team)
                {
                    if ((arrPos.Row + 2) < Board.Height && (arrPos.Column - 2) >= 0 && Board.Pieces(arrPos.Row + 2, arrPos.Column - 2) == null)
                    {
                        possibleTargets[arrPos.Row + 2, arrPos.Column - 2] = true;
                    }
                }
            }

            // NW (4)
            if ((arrPos.Row - 1) >= 0 && (arrPos.Column - 1) >= 0)
            {
                if (Board.Pieces(arrPos.Row - 1, arrPos.Column - 1) == null)
                {
                    possibleTargets[arrPos.Row - 1, arrPos.Column - 1] = true;
                }
                else if (Board.Pieces(arrPos.Row - 1, arrPos.Column - 1).Team != Team)
                {
                    if (((arrPos.Row - 2) >= 0 && (arrPos.Column - 2) >= 0) && Board.Pieces(arrPos.Row - 2, arrPos.Column - 2) == null)
                    {
                        possibleTargets[arrPos.Row - 2, arrPos.Column - 2] = true;
                    }
                }
            }

            return possibleTargets;
        }
    }
}
