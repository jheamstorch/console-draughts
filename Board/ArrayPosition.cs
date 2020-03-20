using System;

namespace Board
{
    class ArrayPosition
    {
        //
        // An integer containing the array row
        public int Row { get; set; }
        //
        // An integer containing the array column
        public int Column { get; set; }

        public ArrayPosition(int row, int column)
        {
            Row = row;
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
                Math.Abs(Row - 8),
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
            return $"[{Row}, {Column}]";
        }
    }
}
