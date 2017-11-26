using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select (r)ock, (p)aper or (s)cissors as your move");

            var inputString = Console.ReadLine().ToLowerInvariant().Trim();

            IPlayer playerOne = new HumanPlayer();

            if (MoveValidator.IsValid(inputString))
                playerOne.Play(MoveValidator.Parse(inputString));
            else
                Console.WriteLine("Invalid input, Select(r)ock, (p)aper or(s)cissors as your move");

            Console.WriteLine("Select (r)ock, (p)aper or (s)cissors as your move");

            inputString = Console.ReadLine().ToLowerInvariant().Trim();

            IPlayer playerTwo = new HumanPlayer();

            if (MoveValidator.IsValid(inputString))
                playerTwo.Play(MoveValidator.Parse(inputString));
            else
                Console.WriteLine("Invalid input, Select(r)ock, (p)aper or(s)cissors as your move");


            var gameCount = 0;

            Console.WriteLine("Playing game");

            var firstGame = new Game(playerOne, playerTwo);

            var firstResult = firstGame.Play();
            gameCount++;

            Console.WriteLine("Game {0}:", gameCount);

            if (firstResult == Result.Draw)
                Console.WriteLine("Result was a draw");
            else
                Console.WriteLine("Player {0} won", firstResult == Result.PlayerOneWins ? "PlayerOne" : "PlayerTwo");

            Console.ReadKey();
        }
    }
}
