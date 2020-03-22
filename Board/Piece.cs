namespace Board
{
    abstract class Piece
    {
        //
        // The symbol of the piece
        private readonly string _symbol;
        
        //
        // Contains the row and column of the piece's position in the board
        public BoardPosition BoardPosition;
        
        //
        // Contains the Team of the piece
        public readonly Team Team;

        protected Piece(string symbol, BoardPosition boardPosition, Team team)
        {
            _symbol = symbol;

            BoardPosition = boardPosition;

            Team = team;
        }

        public override string ToString()
        {
            return _symbol;
        }
    }
}
