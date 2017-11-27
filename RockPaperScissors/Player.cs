using System;

namespace RockPaperScissors
{
    public interface IPlayer
    {

        Move GetPlayerMove();
        Move LastMove { get; }
    }

    public class HumanPlayer : IPlayer
    {
        Move lastMove;

        public Move LastMove { get { return lastMove; } }

        public Move GetPlayerMove()
        {
            bool validMove = false;

            while (!validMove)
            {
                Console.WriteLine("Select (r)ock, (p)aper or (s)cissors as your move, then press ENTER");

                var inputString = Console.ReadLine().ToLowerInvariant().Trim();

                if (MoveValidator.IsValid(inputString))
                {
                    lastMove = (MoveValidator.Parse(inputString));
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("Select(r)ock, (p)aper or(s)cissors as your move, then press ENTER");
                }
            }

            return lastMove;
        }
    }
}