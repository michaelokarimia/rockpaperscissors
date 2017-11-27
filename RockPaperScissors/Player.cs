using System;

namespace RockPaperScissors
{
    public interface IPlayer
    {
        Move LastMove();

        IPlayer Play(Move move);
        bool GetPlayerMove();
    }

    public class HumanPlayer : IPlayer
    {
        Move lastMove;

        public bool GetPlayerMove()
        {
            Console.WriteLine("Select (r)ock, (p)aper or (s)cissors as your move");

            var inputString = Console.ReadLine().ToLowerInvariant().Trim();

            if (MoveValidator.IsValid(inputString))
            {
                this.Play(MoveValidator.Parse(inputString));
                return true;
            }
            else
                Console.WriteLine("Invalid input, Select(r)ock, (p)aper or(s)cissors as your move");

            return false;
        }

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