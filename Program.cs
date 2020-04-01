using System;
using static Board.BoardPosition;
using Board;
using Draughts.Exceptions;
using Draughts;

namespace ConsoleDraughts
{
    class Program
    {
        static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            
            var actualMatch = new DraughtsMatch();
            GameScreen.HomeScreen(actualMatch);

            do
            {
                Console.Clear();
                GameScreen.WriteLineBoard(actualMatch.Board);
                Console.WriteLine();

                GameScreen.WriteLineMatchReport(actualMatch);
                Console.WriteLine();

                Console.Write("Select a piece: ");
                try
                {
                    Piece selectedPiece = actualMatch.SelectPiece(FromStringToBoardPosition(Console.ReadLine()));

                TryMovementAgain:
                    Console.Clear();
                    GameScreen.WriteLineBoard(actualMatch.Board, selectedPiece.PossibleTargets());
                    Console.WriteLine();

                    GameScreen.WriteLineMatchReport(actualMatch);
                    Console.WriteLine();

                    Console.Write("Selected piece: ");
                    GameScreen.WritePiece(selectedPiece);
                    Console.WriteLine($" ({selectedPiece.BoardPosition})");

                    Console.Write("Select a target: ");
                    try
                    {
                        actualMatch.MakeMovement(selectedPiece, actualMatch.SelectTarget(selectedPiece));
                        actualMatch.PassTurn();
                    }
                    catch (FormatException e)
                    {
                        GameScreen.WriteError(e.Message, "Try to follow the next example: e4");
                        goto TryMovementAgain;
                    }
                    catch (InvalidPositionException e)
                    {
                        GameScreen.WriteError(e.Message, "Select a position with white highlight.");
                        goto TryMovementAgain;
                    }
                }
                catch (FormatException e)
                {
                    GameScreen.WriteError(e.Message, "Try to follow the next example: e4");
                }
                catch (InvalidPositionException e)
                {
                    GameScreen.WriteError(e.Message, "Please, select a valid piece.");
                }
            } while (!actualMatch.IsFinished());
        }
    }
}
