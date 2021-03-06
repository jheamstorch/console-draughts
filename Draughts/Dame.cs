﻿using Board;

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
            // 4-----1
            // -4---1-
            // --8-5--
            // ---D---
            // --7-6--
            // -3---2-
            // 3-----2

            bool[,] possibleTargets = new bool[Board.Height, Board.Width];
            TwoDimensionsArrayPosition arrPos = BoardPosition.ToArrayPosition(Board.Height);

            bool withoutCaptures = true;

            // NE (1) (Only catch avaliable)
            for (int arrRow = arrPos.Row - 1, arrColumn = arrPos.Column + 1; arrRow >= 0 && arrColumn < Board.Width; arrRow--, arrColumn++)
            {
                if (Board.Pieces(arrRow, arrColumn) != null)
                {
                    if (Board.Pieces(arrRow, arrColumn).Team != Team && arrRow - 1 >= 0 && arrColumn + 1 < Board.Width && Board.Pieces(arrRow - 1, arrColumn + 1) == null)
                    {
                        possibleTargets[arrRow - 1, arrColumn + 1] = true;
                        withoutCaptures = false;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // SE (2) (Only catch avaliable)
            for (int arrRow = arrPos.Row + 1, arrColumn = arrPos.Column + 1; arrRow < Board.Height && arrColumn < Board.Width; arrRow++, arrColumn++)
            {
                if (Board.Pieces(arrRow, arrColumn) != null)
                {
                    if (Board.Pieces(arrRow, arrColumn).Team != Team && arrRow + 1 < Board.Height && arrColumn + 1 < Board.Width && Board.Pieces(arrRow + 1, arrColumn + 1) == null)
                    {
                        possibleTargets[arrRow + 1, arrColumn + 1] = true;
                        withoutCaptures = false;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // SW (3) (Only catch avaliable)
            for (int arrRow = arrPos.Row + 1, arrColumn = arrPos.Column - 1; arrRow < Board.Height && arrColumn >= 0; arrRow++, arrColumn--)
            {
                if (Board.Pieces(arrRow, arrColumn) != null)
                {
                    if (Board.Pieces(arrRow, arrColumn).Team != Team && arrRow + 1 < Board.Height && arrColumn - 1 >= 0 && Board.Pieces(arrRow + 1, arrColumn - 1) == null)
                    {
                        possibleTargets[arrRow + 1, arrColumn - 1] = true;
                        withoutCaptures = false;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // NW (4) (Only catch avaliable)
            for (int arrRow = arrPos.Row - 1, arrColumn = arrPos.Column - 1; arrRow >= 0 && arrColumn >= 0; arrRow--, arrColumn--)
            {
                if (Board.Pieces(arrRow, arrColumn) != null)
                {
                    if (Board.Pieces(arrRow, arrColumn).Team != Team && arrRow - 1 >= 0 && arrColumn - 1 >= 0 && Board.Pieces(arrRow - 1, arrColumn - 1) == null)
                    {
                        possibleTargets[arrRow - 1, arrColumn - 1] = true;
                        withoutCaptures = false;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (withoutCaptures)
            {
                // NE (5) (Without catch case)
                if (arrPos.Row - 1 >= 0 && arrPos.Column + 1 < Board.Width && Board.Pieces(arrPos.Row - 1, arrPos.Column + 1) == null)
                {
                    possibleTargets[arrPos.Row - 1, arrPos.Column + 1] = true;
                }

                // SE (6) (Without catch case)
                if (arrPos.Row + 1 < Board.Height && arrPos.Column + 1 < Board.Width && Board.Pieces(arrPos.Row + 1, arrPos.Column + 1) == null)
                {
                    possibleTargets[arrPos.Row + 1, arrPos.Column + 1] = true;
                }

                // SW (7) (Without catch case)
                if (arrPos.Row + 1 < Board.Height && arrPos.Column - 1 >= 0 && Board.Pieces(arrPos.Row + 1, arrPos.Column - 1) == null)
                {
                    possibleTargets[arrPos.Row + 1, arrPos.Column - 1] = true;
                }

                // NW (8) (Without catch case)
                if (arrPos.Row - 1 >= 0 && arrPos.Column - 1 >= 0 && Board.Pieces(arrPos.Row - 1, arrPos.Column - 1) == null)
                {
                    possibleTargets[arrPos.Row - 1, arrPos.Column - 1] = true;
                }
            }

            return possibleTargets;
        }
    }
}
