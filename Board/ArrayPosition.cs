using System;

namespace Board
{
    class ArrayPosition
    {
        //
        // An integer containing the array line
        public int Line { get; set; }
        //
        // An integer containing the array column
        public int Column { get; set; }

        public ArrayPosition(int line, int column)
        {
            Line = line;
            Column = column;
        }

        //
        // Summary:
        //     Convert the ArrayPosition to its equivalent BoardPosition
        //
        // Return:
        //     A BoardPosition containing the actual ArrayPosition converted to a BoardPosition
        public BoardPosition ToBoardPosition()
        {
            return new BoardPosition(
                Math.Abs(Line - 8),
                (char)(Column + (int)'a')
            );
        }

        //
        // Example:
        //   Code:
        //     Console.Write(new ArrayPosition(6, 7).ToString());
        //
        //   Console output:
        //     [6, 7]
        public override string ToString()
        {
            return $"[{Line}, {Column}]";
        }
    }
}
