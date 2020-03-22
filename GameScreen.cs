using System;
using Board;
using static Board.TwoDimensionsArrayPosition;

namespace ConsoleDraughts
{
    static class GameScreen
    {
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
            // Summary:
            //     Writes the column letters of the board.
            void WriteColumnLetters()
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
            //    abcdefghij
            WriteColumnLetters();
            //
            //   ╔══════════╗
            Console.WriteLine
            (
                new string(' ', board.Height.ToString().Length)
                + '╔'
                + new string('═', board.Width)
                + "╗"
            );
            //
            // xx║----------║xx
            // x ║----------║ x
            for (int arrRow = 0; arrRow < board.Height; arrRow++)
            {
                //
                // xx║
                // Writes the left number and the '║'.
                Console.Write
                (
                    FromArrayRowToBoardRow(arrRow, board.Height)
                    + new string(' ', board.Height.ToString().Length - FromArrayRowToBoardRow(arrRow, board.Height).ToString().Length)
                    + '║'
                );
                //
                // ----------
                // Writes the pieces.
                for (int arrColumn = 0; arrColumn < board.Width; arrColumn++)
                {
                    if (board.Pieces[arrRow, arrColumn] == null)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        WritePiece(board.Pieces[arrRow, arrColumn]);
                    }
                }
                //
                // ║xx
                // Writes the right number.
                Console.WriteLine
                (
                    '║'
                    + new string(' ', board.Height.ToString().Length - FromArrayRowToBoardRow(arrRow, board.Height).ToString().Length)
                    + FromArrayRowToBoardRow(arrRow, board.Height)
                );
            }
            //
            //   ╚══════════╝
            Console.WriteLine
            (
                new string(' ', board.Height.ToString().Length)
                + '╚'
                + new string('═', board.Width)
                + '╝'
            );
            //
            //    abcdefghij
            WriteColumnLetters();
        }

        //
        // Summary:
        //     Writes the piece with different color for different teams.
        //
        // Parameters:
        //   piece:
        //     The piece to be printed.
        private static void WritePiece(Piece piece)
        {
            if (piece.Team == Team.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write(piece);

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
