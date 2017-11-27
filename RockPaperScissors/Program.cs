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
            IPlayer playerOne = SelectPlayerType("Player One");
            IPlayer playerTwo = SelectPlayerType("Player Two");


            Match match = new Match(playerOne, playerTwo);

            match.Start();



            Console.ReadKey();
        }


        public static IPlayer SelectPlayerType(string name)
        {
            //defaults to human player type
            IPlayer player = new HumanPlayer();

            bool validAnswer = false;
            int answer = 0;
            while (!validAnswer)
            {
                Console.WriteLine("Is {0} a: 1) human, random computer or tactical computer?", name);
                Console.WriteLine("Select 1, 2 or 3 as your answer, followed by pressing the ENTER key");

                int.TryParse(Console.ReadLine(), out answer);

                if (answer == 1)
                {
                    player = new HumanPlayer();
                    validAnswer = true;
                }

            }

            return player;
        }
    }
}
