using Board;

namespace Draughts
{
    class DraughtsMatch
    {
        //
        // The match's board.
        public readonly Board.Board Board;

        public DraughtsMatch()
        {
            Board = new Board.Board(10, 10);

            //
            // Place the red pieces in their initial positions.
            for (int arrLine = 0; arrLine <= 3; arrLine++)
            {
                //
                // Explanation about the value to be assigned to arrColumn variable:
                //
                // Arrray's odd lines will have their frist pieces in column 0,
                // while Even lines will have the frist pieces in the array column 1.
                for (int arrColumn = 1 - arrLine % 2; arrColumn < Board.Width; arrColumn += 2)
                {
                    Board.PlacePiece(
                        new Pawn(new TwoDimensionsArrayPosition(arrLine, arrColumn).ToBoardPosition(Board.Height), Team.Red),
                        new TwoDimensionsArrayPosition(arrLine, arrColumn));
                }
            }

            //
            // Place the white pieces in their initial positions.
            for (int arrLine = 6; arrLine < Board.Height; arrLine++)
            {
                //
                // Explanation about the value to be assigned to arrColumn variable:
                //
                // Arrray's odd lines will have their frist pieces in column 0,
                // while Even lines will have the frist pieces in the array column 1.
                for (int arrColumn = 1 - arrLine % 2; arrColumn < Board.Width; arrColumn += 2)
                {
                    Board.PlacePiece(
                        new Pawn(new TwoDimensionsArrayPosition(arrLine, arrColumn).ToBoardPosition(Board.Height), Team.White),
                        new TwoDimensionsArrayPosition(arrLine, arrColumn));
                }
            }
        }


    }
}
