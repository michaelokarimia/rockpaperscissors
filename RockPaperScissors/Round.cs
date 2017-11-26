using System;

namespace Tests
{
    public class Round
    {
        private Player p1;
        private Player p2;


        public Round(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }


        public Result Play()
        {
            //rock beats scissors, p1 wins
            if (p1.LastMove == Move.Rock && p2.LastMove == Move.Scissors)
                return Result.PlayerOneWins;

            return Result.Draw;
        }


    }
}