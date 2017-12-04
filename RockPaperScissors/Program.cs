using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer playerOne = SelectPlayerType("Player One");
            IPlayer playerTwo = SelectPlayerType("Player Two");

            Match match = new Match(playerOne, playerTwo);

            var matchResult = match.Start();

            if(matchResult == MatchResult.PlayerOneWins)
            {
                Console.WriteLine("Player One won the match!");
            }

            if (matchResult == MatchResult.PlayerTwoWins)
            {
                Console.WriteLine("Player Two won the match!");
            }

            if(matchResult == MatchResult.Draw)
            {
                Console.WriteLine("It was a draw");
            }

            Console.ReadKey();
        }


        public static IPlayer SelectPlayerType(string name)
        {
            bool validAnswer = false;
            int answer = 0;
            while (!validAnswer)
            {
                Console.WriteLine("Is {0} a: 1) human, 2) random computer or 3) tactical computer?", name);
                Console.WriteLine("Select 1, 2 or 3 as your answer, followed by pressing the ENTER key");

                int.TryParse(Console.ReadLine(), out answer);


                switch (answer)
                {
                    case 1:
                        return new HumanPlayer();
                    case 2:
                        return new RandomComputerPlayer();
                    case 3:
                        return new TacticalComputerPlayer();
                    default:
                        break;
                }
            }

            throw new ArgumentOutOfRangeException("Allowed player types are: Human, Random computer and Tatical computer");
        }
    }
}
