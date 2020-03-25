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
        //   Converts the BoardPosition.Row to its equvalent array row.
        //
        // Parameters:
        //   boardRow:
        //     The BoardPosition.Row to be converted.
        //
        //   numberArrayRows:
        //     The total number of elements in the frist dimension ("row" dimension) of the array.
        //
        // Returns:
        //     The equivalent array row.
        public static int FromBoardRowToArrayRow(int boardRow, int numberArrayRows)
        {
            return numberArrayRows - boardRow;
        }

        //
        // Summary:
        public static int FromBoardColumnToArrayColumn(char boardColumn)
        {
            return boardColumn - 'a';
        }
        //
        // Summary:
        //     Convert the BoardPosition to its equivalent TwoDimensionsArrayPosition.
        //
        // Parameters:
        //   numberArrayRows:
        //     The total number of elements in the frist dimension ("row" dimension) of the array.
        //
        // Returns:
        //     An TwoDimensionsArrayPosition containing the actual BoardPosition converted to an TwoDimensionsArrayPosition.
        public TwoDimensionsArrayPosition ToArrayPosition(int numberArrayRows)
        {
            return new TwoDimensionsArrayPosition
            (
                FromBoardRowToArrayRow(Row, numberArrayRows),
                FromBoardColumnToArrayColumn(Column)
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
