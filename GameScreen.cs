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
        private static void WriteLineTeam(Team team)
        {
            if (team == Team.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(team);
            Console.WriteLine();

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

            WriteLineBoard(match.Board);
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
        public static void WriteLineMatchReport(DraughtsMatch match)
        {
            Console.WriteLine("Turn: " + match.Round);
            Console.Write("Waiting movement: ");
            WriteLineTeam(match.TurnPlayer);
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
        public static void WriteLineBoard(Board.Board board)
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
        public static void WriteLineBoard(Board.Board board, bool[,] targets)
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

        //
        // Summary:
        //     Write a text in the style of an error; using red to highlight
        //     the information.
        //
        // Parameters:
        //   errorMessage:
        //     The message of the error.
        //
        //   errorTip:
        //     A tip about the error and how to avoid it.
        public static void WriteError(string errorMessage, string errorTip)
        {
            //
            // Summary:
            //     Writes a string as a Console.Write(), but this method can
            //     write a string anywhere in the console buffer.
            //
            // Parameters:
            //   leftCursorPos:
            //     The column to start with.
            //   
            //   topCursorPos:
            //     The line you are going to write on.
            //
            //   str:
            //     The string to be writed.
            static void WriteString(int leftCursorPos, int topCursorPos, string str)
            {
                Console.SetCursorPosition(leftCursorPos, topCursorPos);
                Console.Write(str);
            }

            string header = "* * Oops! An error has occurred * *";

            // The 'S' means Start and the 'E' means End.
            int squareColumnS = (int)Math.Ceiling((double)((Console.WindowWidth - Math.Max(errorMessage.Length, header.Length) - 2) / 2));
            int squareColumnE = squareColumnS + Math.Max(errorMessage.Length, Math.Max(errorTip.Length, 35)) + 2;

            // To ensure that the header will be centered
            if (header.Length % 2 != (squareColumnE - squareColumnS) % 2)
            {
                squareColumnE++;
            }

            int squareRowS = (Console.WindowHeight - 7 - 2) / 2;
            int squareRowE = squareRowS + 7 + 1;

            // This generates the square of the error screen.
            Console.BackgroundColor = ConsoleColor.DarkRed;
            for (int row = 0; row <= squareRowE - squareRowS; row++)
            {
                Console.SetCursorPosition(squareColumnS, squareRowS + row);
                Console.Write(new string(' ', squareColumnE - squareColumnS));
            }

            // Indicates the smallest column of the console window avaliable to write and the its limit.
            // The 'S' means Start and the 'E' means End.
            int writableColumnS = squareColumnS + 1;
            int writableColumnE = squareColumnE - 1;

            // Indicates the smallest row of the console window avaliable to write.
            // The 'S' means Start and the 'E' means End.
            int writableRowS = squareRowS + 1;

            // This writes the header in the center of the error square.
            WriteString(((writableColumnE - writableColumnS - header.Length) / 2) + writableColumnS, writableRowS, header);
            
            WriteString(writableColumnS, writableRowS + 2, errorMessage);
            WriteString(writableColumnS, writableRowS + 3, errorTip);


            WriteString(writableColumnS, writableRowS + 6, "Press any key to continue...");
            Console.ReadKey(true);

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
