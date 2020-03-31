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
            var actualMatch = new DraughtsMatch();
            GameScreen.HomeScreen(actualMatch);

            do
            {
                Console.Clear();
                GameScreen.WriteLineBoard(actualMatch.Board);
                Console.WriteLine();

                GameScreen.WriteLineMatchReport(actualMatch);
                Console.WriteLine();

                Console.Write("Select piece: ");
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
                        actualMatch.MakeMovement(selectedPiece, FromStringToBoardPosition(Console.ReadLine()));
                        actualMatch.PassTurn();
                    }
                    catch (FormatException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Please, follow the next example: e4");
                        Console.WriteLine();

                        Console.Write("Press any key to continue...");
                        Console.ReadKey(true);
                        goto TryMovementAgain;
                    }
                    catch (InvalidPositionException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Please, select a valid target.");
                        Console.WriteLine();

                        Console.Write("Press any key to continue...");
                        Console.ReadKey(true);
                        goto TryMovementAgain;
                    }
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please, follow the next example: e4");
                    Console.WriteLine();

                    Console.Write("Press any key to continue...");
                    Console.ReadKey(true);
                }
                catch (InvalidPositionException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please, select a valid piece.");
                    Console.WriteLine();

                    Console.Write("Press any key to continue...");
                    Console.ReadKey(true);
                }
            } while (!actualMatch.IsFinished());
        }
    }
}
