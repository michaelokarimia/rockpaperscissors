using System;

namespace RockPaperScissors
{
    public class MoveValidator
    {
        public static bool IsValid(string rawinput)
        {
            var input = rawinput.ToLower().Trim();

            switch (input)
            {
                case "rock":
                case "r":
                case "paper":
                case "p":
                case "scissors":
                case "s":
                    return true;

                default:
                    return false;
            }
        }

        public static Move Parse(string input)
        {
            input = input.ToLowerInvariant().Trim();

            switch (input)
            {
                case "rock":
                case "r":
                    return Move.Rock;
                case "paper":
                case "p":
                    return Move.Paper;
                case "scissors":
                case "s":
                    return Move.Scissors;

                default:
                    throw new ArgumentOutOfRangeException("Only, Rock, Paper or Scissors are valid inputs");
            }
        }
    }
}

       
    
