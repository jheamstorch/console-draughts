using Board;

namespace Draughts
{
    class Dame : Piece
    {
        //
        // Defines that 'D' will be the symbol of the Dame
        public Dame(BoardPosition boardPosition, Team team) : base("D", boardPosition, team)
        {
        }
    }
}
