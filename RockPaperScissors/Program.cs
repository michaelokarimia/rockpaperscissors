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

            var p1string = Console.ReadLine().ToLowerInvariant().Trim();

            HumanPlayer human = new HumanPlayer();

            if (MoveValidator.IsValid(p1string))
                human.Play(MoveValidator.Parse(p1string));
            else
                Console.WriteLine("Invalid input, Select(r)ock, (p)aper or(s)cissors as your move");

            Console.ReadKey();
        }
    }
}
