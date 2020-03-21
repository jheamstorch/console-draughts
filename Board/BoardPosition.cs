namespace Board
{
    class BoardPosition
    {
        //
        // An integer containing the board row.
        public int Row { get; set; }
        //
        // A char containing the board column.
        public char Column { get; set; }

        public BoardPosition(int row, char column)
        {
            Row = row;
            Column = column;
        }

        //
        // Summary:
        //     Convert the BoardPosition to its equivalent TwoDimensionsArrayPosition.
        //
        // Parameters:
        //   numberArrayRows:
        //     The total number of elements in the frist dimension ("row" dimension) of the array.
        //
        // Return:
        //     An TwoDimensionsArrayPosition containing the actual BoardPosition converted to an TwoDimensionsArrayPosition.
        public TwoDimensionsArrayPosition ToArrayPosition(int numberArrayRows)
        {
            return new TwoDimensionsArrayPosition
            (
                numberArrayRows - Row,
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
            return $"{Column}{Row}";
        }
    }
}
