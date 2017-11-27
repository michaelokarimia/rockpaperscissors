using System;

namespace RockPaperScissors
{
    public class RandomComputerPlayer : IPlayer
    {
        private Move lastMove;
        private Random rand;

        public Move LastMove { get { return lastMove; } }

        public RandomComputerPlayer()
        {
            rand = new Random();
        }

        public Move GetPlayerMove()
        {
            int choice = rand.Next(1, 4);

            lastMove = (Move)choice;

            return lastMove;
        }
    }
}