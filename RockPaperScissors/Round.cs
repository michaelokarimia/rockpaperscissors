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
            // same moves will always result in a draw
            if (p1.LastMove == p2.LastMove)
                return Result.Draw;


            //rock beats scissors, p1 wins
            if (p1.LastMove == Move.Rock && p2.LastMove == Move.Scissors)
                return Result.PlayerOneWins;

            //rock loses against paper





            //scissors beats paper

            if (p1.LastMove == Move.Scissors && p2.LastMove == Move.Paper)
                return Result.PlayerOneWins;




            //paper loses against Scissors

            if (p1.LastMove == Move.Paper && p2.LastMove == Move.Scissors)
                return Result.PlayerTwoWins;


            return Result.Draw;
        }


    }
}