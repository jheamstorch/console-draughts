using System;
using Board;
using static Board.TwoDimensionsArrayPosition;
using Draughts;

namespace ConsoleDraughts
{
    //
    // Summary:
    //     Manages all actions on the console, like write the board, match
    //     information, error display and much more.
    static class GameScreen
    {
        //
        // Summary:
        //     Writes the column letters of the board.
        //
        // Parameters:
        //   board:
        //     Is the board from where the columns are.
        private static void WriteColumnLetters(Board.Board board)
        {
            //
            // Creates the space before the letters begin.
            string columnLetters = new string(' ', board.Height.ToString().Length + 1);
            //
            // Adds the letters.
            for (int i = 0; i < board.Width; i++)
            {
                columnLetters += (char)(i + 'a');
            }
            //
            // Writes the result.
            Console.WriteLine(columnLetters);
        }

        //
        // Summary:
        //     Write the name of the team with different colors for different teams.
        //
        // Parameters:
        //   team:
        //     The team to be writen.
        private static void WriteTeam(Team team)
        {
            if (team == Team.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(team);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //
        // Summary:
        //     Show a home screen.
        public static void HomeScreen(DraughtsMatch match)
        {
            //
            // Write "DRAUGHTS" centered while changing the color of the letters between red and gray.
            Console.Write("    ");
            foreach (var letter in "DRAUGHTS")
            {
                Console.ForegroundColor = (Console.ForegroundColor == ConsoleColor.Gray) ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.Write(letter);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine();

            WriteBoard(match.Board);
            Console.WriteLine();

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        //
        // Summary:
        //     Write all information about the match.
        //
        // Parameters:
        //   match:
        //     The departure from where the information will be analyzed.
        public static void MatchReport(DraughtsMatch match)
        {
            Console.WriteLine("Turn: " + match.Round);
            Console.Write("Waiting movement: ");
            WriteTeam(match.TurnPlayer);
            Console.WriteLine();
        }

        //
        // Summary:
        //     Writes the piece with different color for different teams.
        //
        // Parameters:
        //   piece:
        //     The piece to be printed.
        public static void WritePiece(Piece piece)
        {
            if (piece.Team == Team.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(piece);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //
        // Summary:
        //     Writes the board with row and column indicators and board limits.
        //
        // Parameters:
        //   board:
        //     The board to be printed.
        public static void WriteBoard(Board.Board board)
        {
            //
            // Output example with a 10x10 board:
            //    abcdefghij
            //   ╔══════════╗
            // 10║-P-P-P-P-P║10
            // 9 ║P-P-P-P-P-║ 9
            // 8 ║-P-P-P-P-P║ 8
            // 7 ║P-P-P-P-P-║ 7
            // 6 ║----------║ 6
            // 5 ║----------║ 5
            // 4 ║-P-P-P-P-P║ 4
            // 3 ║P-P-P-P-P-║ 3
            // 2 ║-P-P-P-P-P║ 2
            // 1 ║P-P-P-P-P-║ 1
            //   ╚══════════╝
            //    abcdefghij

            //
            //    abcdefghij
            WriteColumnLetters(board);
            //
            //   ╔══════════╗
            Console.WriteLine(
                new string(' ', board.Height.ToString().Length)
                + '╔'
                + new string('═', board.Width)
                + "╗");
            //
            // xx║----------║xx
            // x ║----------║ x
            for (int arrRow = 0; arrRow < board.Height; arrRow++)
            {
                //
                // xx║
                // Writes the left number and the '║'.
                Console.Write(
                    FromArrayRowToBoardRow(arrRow, board.Height)
                    + new string(' ', board.Height.ToString().Length - FromArrayRowToBoardRow(arrRow, board.Height).ToString().Length)
                    + '║');
                //
                // ----------
                // Writes the pieces.
                for (int arrColumn = 0; arrColumn < board.Width; arrColumn++)
                {
                    if (board.Pieces(arrRow, arrColumn) == null)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        WritePiece(board.Pieces(arrRow, arrColumn));
                    }
                }
                //
                // ║xx
                // Writes the right number.
                Console.WriteLine(
                    '║'
                    + new string(' ', board.Height.ToString().Length - FromArrayRowToBoardRow(arrRow, board.Height).ToString().Length)
                    + FromArrayRowToBoardRow(arrRow, board.Height));
            }
            //
            //   ╚══════════╝
            Console.WriteLine(
                new string(' ', board.Height.ToString().Length)
                + '╚'
                + new string('═', board.Width)
                + '╝');
            //
            //    abcdefghij
            WriteColumnLetters(board);
        }

        //
        // Summary:
        //     Writes the board with row and column indicators and board limits and marking the targets.
        //
        // Parameters:
        //   board:
        //     The board to be printed.
        //
        //   targets:
        //     An array marking the positions of the board to be highlighted.
        public static void WriteBoard(Board.Board board, bool[,] targets)
        {
            //
            // Output example with a 10x10 board:
            //    abcdefghij
            //   ╔══════════╗
            // 10║-P-P-P-P-P║10
            // 9 ║P-P-P-P-P-║ 9
            // 8 ║-P-P-P-P-P║ 8
            // 7 ║P-P-P-P-P-║ 7
            // 6 ║----------║ 6
            // 5 ║----------║ 5
            // 4 ║-P-P-P-P-P║ 4
            // 3 ║P-P-P-P-P-║ 3
            // 2 ║-P-P-P-P-P║ 2
            // 1 ║P-P-P-P-P-║ 1
            //   ╚══════════╝
            //    abcdefghij

            //
            //    abcdefghij
            WriteColumnLetters(board);
            //
            //   ╔══════════╗
            Console.WriteLine(
                new string(' ', board.Height.ToString().Length)
                + '╔'
                + new string('═', board.Width)
                + "╗");
            //
            // xx║----------║xx
            // x ║----------║ x
            for (int arrRow = 0; arrRow < board.Height; arrRow++)
            {
                //
                // xx║
                // Writes the left number and the '║'.
                Console.Write(
                    FromArrayRowToBoardRow(arrRow, board.Height)
                    + new string(' ', board.Height.ToString().Length - FromArrayRowToBoardRow(arrRow, board.Height).ToString().Length)
                    + '║');
                //
                // ----------
                // Writes the pieces.
                for (int arrColumn = 0; arrColumn < board.Width; arrColumn++)
                {
                    if (targets[arrRow, arrColumn])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    if (board.Pieces(arrRow, arrColumn) == null)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        WritePiece(board.Pieces(arrRow, arrColumn));
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                }
                //
                // ║xx
                // Writes the right number.
                Console.WriteLine(
                    '║'
                    + new string(' ', board.Height.ToString().Length - FromArrayRowToBoardRow(arrRow, board.Height).ToString().Length)
                    + FromArrayRowToBoardRow(arrRow, board.Height));
            }
            //
            //   ╚══════════╝
            Console.WriteLine(
                new string(' ', board.Height.ToString().Length)
                + '╚'
                + new string('═', board.Width)
                + '╝');
            //
            //    abcdefghij
            WriteColumnLetters(board);
        }

        /*//
        // Summary:
        //
        public static void ShowError()
        {

        }*/
    }
}
