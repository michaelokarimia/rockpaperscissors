using System;

namespace RockPaperScissors
{
    public class RandomComputerPlayer : IPlayer
    {
        private Move lastMove;
        private Random rand;


        public RandomComputerPlayer()
        {
            rand = new Random();
        }

        public bool GetPlayerMove()
        {
            int choice = rand.Next(1,4);

            lastMove = (Move)choice;

            return true;
        }

        public Move LastMove()
        {
            return this.lastMove;
        }

        public IPlayer Play(Move move)
        {
            lastMove = move;
            return this;
        }
    }
}