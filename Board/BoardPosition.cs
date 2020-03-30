namespace Board
{
    //
    // Summary:
    //     Represents a position in a Board.
    class BoardPosition
    {
        //
        // An integer containing the board row.
        public int Row { get; set; }
        //
        // A char containing the board column.
        public char Column { get; set; }

        //
        // Summary:
        //     Instantiates a BoardPosition, with its row and column.
        //
        // Parameters:
        //   row:
        //     Position's row.
        //   column:
        //     Position's column.
        public BoardPosition(int row, char column)
        {
            Row = row;
            Column = column;
        }

        //
        // Summary:
        //     Try to convert a string to a BoardPosition.
        // 
        // Parameters:
        //   str:
        //     The string to be converted.
        //
        // Returns:
        //     A BoardPosition equivalent to the string.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     If the string does not represent a BoardPosition.
        public static BoardPosition FromStringToBoardPosition(string str)
        {
            string exceptionMessage = $"Your input \"{str}\" does not represent a BoardPosition.";
            if (str.Length > 3 || str.Length < 2)
            {
                throw new System.FormatException(exceptionMessage);
            }
            else if (!char.IsLetter(str, 0))
            {
                throw new System.FormatException(exceptionMessage);
            }
            else
            {
                int.TryParse(str.Substring(1), out int tryParse);
                if (tryParse == 0)
                {
                    throw new System.FormatException(exceptionMessage);
                }
            }

            return new BoardPosition(int.Parse(str.Substring(1)), str[0]);
        }

        //
        // Summary:
        //   Converts a integer (representing a board row) to its equvalent array row.
        //
        // Parameters:
        //   boardRow:
        //     The integer representing a board row to be converted.
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
        //     Converts a char (representing a board column) to its equvalent array column.
        //
        // Parameters:
        //   boardColumn:
        //     The char representing a board column to be converted.
        //
        // Returns:
        //     The equivalent array column.
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
