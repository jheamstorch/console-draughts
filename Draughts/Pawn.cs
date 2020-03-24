using Board;

namespace Draughts
{
    class Pawn : Piece
    {
        //
        // Defines that 'P' will be the symbol of the Pawn
        public Pawn(BoardPosition boardPosition, Team team) : base("P", boardPosition, team)
        {
        }
    }
}
