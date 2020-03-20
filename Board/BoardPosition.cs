﻿namespace Board
{
    class BoardPosition
    {
        //
        // An integer containing the board line
        public int Line { get; set; }
        //
        // A char containing the board column
        public char Column { get; set; }

        public BoardPosition(int line, char column)
        {
            Line = line;
            Column = column;
        }

        //
        // Summary:
        //     Convert the BoardPosition to its equivalent ArrayPosition
        //
        // Return:
        //     An ArrayPosition containing the actual BoardPosition converted to an ArrayPosition
        public ArrayPosition ToArrayPosition()
        {
            return new ArrayPosition
            (
                8 - Line,
                Column - 'a'
            );
        }

        //
        // Example:
        //   Code:
        //     Console.Write(new BoardPosition(6, 'h').ToString());
        //
        //   Console output:
        //     h6
        public override string ToString()
        {
            return $"{Column}{Line}";
        }
    }
}
