using System;

namespace Tests
{
    public class Round
    {
        private Player p1;
        private Player p2;
        private bool player1Wins;

        public Round(Player p1, Player p2)
        {
            player1Wins = false;

            this.p1 = p1;
            this.p2 = p2;
        }

        public bool IsPlayer1Wins()
        {
            return player1Wins;
        }

        public void Play()
        {
            //rock beats scissors
            if (p1.LastMove == Move.Rock && p2.LastMove == Move.Scissors)
                player1Wins = true;
               

        }

        
    }
}