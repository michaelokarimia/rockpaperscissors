using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    public class Match
    {
        private IPlayer playerOne;
        private IPlayer playerTwo;
        private int GamesInMatchCount;
        private int completedGamesCount;

        public Match(IPlayer playerOne, IPlayer playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            GamesInMatchCount = 3;
            completedGamesCount = 0;
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

                completedGamesCount++;
            }

            if (p1WinCount > p2WinCount)
                return Result.PlayerOneWins;
            if (p2WinCount > p1WinCount)
                return Result.PlayerTwoWins;

            return Result.Draw;
        }

        public bool IsGameOver()
        {
            return GamesInMatchCount == completedGamesCount;
        }
    }
}