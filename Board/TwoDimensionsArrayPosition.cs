namespace Board
{
    //
    // Summary:
    //     Represents a position on a two dimensions array.
    class TwoDimensionsArrayPosition
    {
        //
        // An integer containing the array row.
        public int Row { get; set; }
        //
        // An integer containing the array column.
        public int Column { get; set; }

        //
        // Summary:
        //     Instanciates a TwoDimensionsArrayPosition with its row and column.
        //
        // Parameters:
        //   row:
        //     Position's row.
        //
        //   column:
        //     Position's column.
        public TwoDimensionsArrayPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        //
        // Summary:
        //     Converts only a integer (representing a array) row to its equivalent board row.
        //
        // Parameters:
        //   arrRow:
        //     The integer representing a array row to be converted.
        //
        //   numberBoardRows:
        //     The total number of rows in the board.
        //
        // Returns:
        //     The array row's equivalent board line.
        public static int FromArrayRowToBoardRow(int arrRow, int numberBoardRows)
        {
            return numberBoardRows - arrRow;
        }

        //
        // Summary:
        //     Converts only a integer (representing a array column) to its equivalent board column.
        //
        // Parameters:
        //   arrColumn:
        //     The integer representing a array column to be converted.
        //
        // Returns:
        //     The array column's equivalent board column.
        public static char FromArrayColumnToBoardColumn(int arrColumn)
        {
            return (char)(arrColumn + (int)'a');
        }

        //
        // Summary:
        //     Convert the TwoDimensionsArrayPosition to its equivalent BoardPosition.
        //
        // Parameters:
        //   numberBoardRows:
        //     The total number of rows in the board.
        //
        // Returns:
        //     A BoardPosition containing the actual TwoDimensionsArrayPosition converted to a BoardPosition.
        public BoardPosition ToBoardPosition(int numberBoardRows)
        {
            return new BoardPosition(
                FromArrayRowToBoardRow(Row, numberBoardRows),
                FromArrayColumnToBoardColumn(Column));
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
