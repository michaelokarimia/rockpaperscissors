using System;
using System.Collections.Generic;

namespace Tests
{
    public class Match
    {
        private Player playerOne;
        private Player playerTwo;

        public Match(Player playerOne, Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }

        public Result ComputeMatchResult(List<Game> games)
        {
            var drawCount = 0;
            var p1WinCount = 0;
            var p2WinCount = 0;

            foreach(Game game in games)
            {
                var result = game.Play();
                if (result == Result.Draw)
                    drawCount++;
                if (result == Result.PlayerOneWins)
                    p1WinCount++;
                if (result == Result.PlayerTwoWins)
                    p2WinCount++;
            }

            if (p1WinCount > p2WinCount)
                return Result.PlayerOneWins;
            if (p2WinCount > p1WinCount)
                return Result.PlayerTwoWins;

            return Result.Draw;
        }
    }
}