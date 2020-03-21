namespace Board
{
    class TwoDimensionsArrayPosition
    {
        //
        // An integer containing the array row.
        public int Row { get; set; }
        //
        // An integer containing the array column.
        public int Column { get; set; }

        public TwoDimensionsArrayPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        //
        // Summary:
        //     Convert the TwoDimensionsArrayPosition to its equivalent BoardPosition.
        //
        // Parameters:
        //   numberBoardRows:
        //     The total number of rows in the board.
        //
        // Return:
        //     A BoardPosition containing the actual TwoDimensionsArrayPosition converted to a BoardPosition.
        public BoardPosition ToBoardPosition(int numberBoardRows)
        {
            return new BoardPosition(
                numberBoardRows - Row,
                (char)(Column + (int)'a')
            );
        }

        //
        // Example:
        //   Code:
        //     Console.Write(new TwoDimensionsArrayPosition(6, 7).ToString());
        //
        //   Console output:
        //     [6, 7]
        public override string ToString()
        {
            return $"[{Row}, {Column}]";
        }
    }
}
