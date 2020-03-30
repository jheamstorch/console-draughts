﻿using System.Collections.Generic;
using System;
using static Board.BoardPosition;
using Board;
using Draughts.Exceptions;

namespace Draughts
{
    class DraughtsMatch
    {
        //
        // A collection that contains all pieces of the team Red.
        private HashSet<Piece> RedPieces { get; } = new HashSet<Piece>();
        //
        // A collection that contains all pieces of the team White.
        private HashSet<Piece> WhitePieces { get; } = new HashSet<Piece>();
        //
        // The match's board.
        public Board.Board Board { get; } = new Board.Board(10, 10);
        //
        // The turn counter.
        public int Round { get; private set; }
        //
        // Indicates the player playing the current turn.
        public Team TurnPlayer { get; private set; }

        //
        // Summary:
        //     The basic constructor of a DraughtsMatch.s
        public DraughtsMatch()
        {
            //
            // Place the red pieces in their initial positions and place the piece in a collection.
            for (int arrRow = 0; arrRow <= 3; arrRow++)
            {
                //
                // Explanation about the value to be assigned to arrColumn variable:
                //
                // Arrray's odd lines will have their frist pieces in column 0,
                // while Even lines will have the frist pieces in the array column 1.
                for (int arrColumn = 1 - arrRow % 2; arrColumn < Board.Width; arrColumn += 2)
                {
                    Board.PlacePiece(
                        new Pawn(new TwoDimensionsArrayPosition(arrRow, arrColumn).ToBoardPosition(Board.Height), Board, Team.Red),
                        new TwoDimensionsArrayPosition(arrRow, arrColumn).ToBoardPosition(Board.Height));

                    RedPieces.Add(Board.Pieces(arrRow, arrColumn));
                }
            }

            //
            // Place the white pieces in their initial positions and place the piece in a collection.
            for (int arrRow = 6; arrRow < Board.Height; arrRow++)
            {
                //
                // Explanation about the value to be assigned to arrColumn variable:
                //
                // Arrray's odd lines will have their frist pieces in column 0,
                // while Even lines will have the frist pieces in the array column 1.
                for (int arrColumn = 1 - arrRow % 2; arrColumn < Board.Width; arrColumn += 2)
                {
                    Board.PlacePiece(
                        new Pawn(new TwoDimensionsArrayPosition(arrRow, arrColumn).ToBoardPosition(Board.Height), Board, Team.White),
                        new TwoDimensionsArrayPosition(arrRow, arrColumn).ToBoardPosition(Board.Height));

                    WhitePieces.Add(Board.Pieces(arrRow, arrColumn));
                }
            }

            Round = 1;
            TurnPlayer = Team.White;
        }

        //
        // Summary:
        //     Select the piece to fight.
        // 
        // Parameters:
        //   position:
        //     The position in the board selected.
        //
        // Returns:
        //     The piece in the position.
        //
        // Exceptions:
        //   T:Draughts.Exceptions.InvalidPositionException:
        //     It'll be throw when the player reports a position with no piece
        //     or when he tries to select an opposing piece or when he tries to
        //     select a piece with zero Piece.PossibleTargets().
        public Piece SelectPiece(BoardPosition position)
        {
            if (position.Row > Board.Height || (position.Column - 'a') >= Board.Width)
            {
                throw new InvalidPositionException("The informed position is beyond the limits of the board.");
            }
            else if (Board.Pieces(position) == null)
            {
                throw new InvalidPositionException("You cannot select a position without piece.");
            }
            else if (Board.Pieces(position).Team != TurnPlayer)
            {
                throw new InvalidPositionException("You cannot select an opposing piece.");
            }
            else if (Board.Pieces(position).TargetsCount() == 0)
            {
                throw new InvalidPositionException("You cannot select a piece without avaliable targets.");
            }
            else
            {
                return Board.Pieces(position);
            }
        }

        //
        // Summary:
        //     Make the move, this also includes catching a possible piece in the process.
        //
        // Parameters:
        //   origin:
        //     The piece that will make its move.
        //
        //   target:
        //     The position of the final destination of the Piece origin.
        public void MakeMovement(Piece origin, BoardPosition target)
        {
            if (target.Row > Board.Height || (target.Column - 'a') >= Board.Width)
            {
                throw new InvalidPositionException("The informed target's position is beyond the limits of the board.");
            }
            else if (!origin.PossibleTargets()[FromBoardRowToArrayRow(target.Row, Board.Height), FromBoardColumnToArrayColumn(target.Column)])
            {
                throw new InvalidPositionException("The informed target is no avaliable for this piece.");
            }
            else
            {
                TwoDimensionsArrayPosition originArrPos = origin.BoardPosition.ToArrayPosition(Board.Height);
                TwoDimensionsArrayPosition targetArrPos = target.ToArrayPosition(Board.Height);

                // If the target results in a capture
                if (Math.Abs(originArrPos.Row - targetArrPos.Row) == 2)
                {
                    // The 'P' represents a piece, not a Pawn itself or a Dame, and the 'E' an enemy piece.
                    //
                    // 4---1
                    // -E-E-
                    // --P--
                    // -E-E-
                    // 3---2

                    TwoDimensionsArrayPosition piece2BCapPos;
                    // Locate and set the position of the piece to be captured
                    if ((originArrPos.Column - targetArrPos.Column) == -2) // NE && SE
                    {
                        if ((originArrPos.Row - targetArrPos.Row) == 2) // NE (1)
                        {
                            piece2BCapPos = new TwoDimensionsArrayPosition(originArrPos.Row - 1, originArrPos.Column + 1);
                        }
                        else // SE (2)
                        {
                            piece2BCapPos = new TwoDimensionsArrayPosition(originArrPos.Row + 1, originArrPos.Column + 1);
                        }
                    }
                    else // SW && NW
                    {
                        if ((originArrPos.Row - targetArrPos.Row) == -2) // SW (3)
                        {
                            piece2BCapPos = new TwoDimensionsArrayPosition(originArrPos.Row + 1, originArrPos.Column - 1);
                        }
                        else // NW (4)
                        {
                            piece2BCapPos = new TwoDimensionsArrayPosition(originArrPos.Row - 1, originArrPos.Column - 1);
                        }
                    }


                    if (TurnPlayer == Team.Red)
                    {
                        WhitePieces.Remove(Board.TakePiece(piece2BCapPos));
                    }
                    else
                    {
                        RedPieces.Remove(Board.TakePiece(piece2BCapPos));
                    }
                }

                // Take the origin from the board and place it in the target
                Board.PlacePiece(Board.TakePiece(origin.BoardPosition), target);

                // If the Red pawn or a White pawn is in its promotion area it'll be promoted
                switch (Board.Pieces(target))
                {
                    case Pawn _ when Board.Pieces(target).Team == Team.Red && target.Row == 1:
                    case Pawn _ when Board.Pieces(target).Team == Team.White && target.Row == 10:
                        Promotion(Board.Pieces(target) as Pawn);
                        break;
                }
            }
        }

        //
        // Summary:
        //     Promotes the Pawn to a Dame.
        //
        // Parameters:
        //   pawn:
        //     The pawn to be promoted.
        private void Promotion(Pawn pawn)
        {
            Board.PlacePiece(new Dame(pawn.BoardPosition, pawn.Board, pawn.Team), pawn.BoardPosition);
        }

        //
        // Summary:
        //     This passes the turn of the game.
        public void PassTurn()
        {
            Round++;
            TurnPlayer = (TurnPlayer == Team.Red) ? Team.White : Team.Red;
        }

        //
        // Summary:
        //     This goes back the turn.
        private void GoBackTurn()
        {
            Round--;
            TurnPlayer = (TurnPlayer == Team.Red) ? Team.White : Team.Red;
        }

        //
        // Summary:
        //     Checks if any team lose.
        // 
        // Returns:
        //     A bool indicating if any team don't have more pieces.
        public bool IsFinished()
        {
            if (WhitePieces.Count == 0 || RedPieces.Count == 0)
            {
                // It's because after the winner's final move the turn is passed
                // and this causes the result to be incorrect both in the number
                // of Rounds and in the winner itself.
                GoBackTurn();
                return true;
            }

            return false;
        }
    }
}
