namespace RockPaperScissors
{
    public interface IPlayer
    {
        Move LastMove();

        IPlayer Play(Move move);
             
    }

    public class HumanPlayer : IPlayer
    {
        Move lastMove;

        public Move LastMove()
        {
            return lastMove;
        }

        public IPlayer Play(Move move)
        {
            lastMove = move;
            return this;
        }
    }
}