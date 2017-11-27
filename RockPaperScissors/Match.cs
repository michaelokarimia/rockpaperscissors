using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    public class Match
    {
        private IPlayer playerOne;
        private IPlayer playerTwo;
        private int MaxGamesInMatch;
        private int completedGamesCount;
        private MatchState state;

        public Match(IPlayer playerOne, IPlayer playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            
            //increase MaxGames in match to add more rounds
            MaxGamesInMatch = 3;
            completedGamesCount = 0;
            state = MatchState.Incomplete;
            
        }

        public MatchResult Start()
        {
            var p1WinCount = 0;
            var p2WinCount = 0;


            while (state != MatchState.MatchOver)
            {
                var gameResult = PlayGame();

                if (gameResult == GameResult.PlayerOneWins)
                    p1WinCount++;
                if (gameResult == GameResult.PlayerTwoWins)
                    p2WinCount++;

                if (completedGamesCount == MaxGamesInMatch)
                {
                    state = MatchState.MatchOver;
                }
            }

            if (p1WinCount > p2WinCount)
                return MatchResult.PlayerOneWins;
            else if (p2WinCount > p1WinCount)
                return MatchResult.PlayerTwoWins;
            else
                return MatchResult.Draw;

            throw new InvalidProgramException("Should have returned a valid MatchResult");
          
        }

        private GameResult PlayGame()
        {
            Console.WriteLine("Playing game");

            var game = new Game(playerOne, playerTwo);

            var gameResult = game.Play();

            Console.WriteLine("Player One move was {0}", playerOne.LastMove);
            Console.WriteLine("Player Two move was {0}", playerTwo.LastMove);


            Console.WriteLine("Game {0}:", completedGamesCount +1);

            if (gameResult == GameResult.Draw)
                Console.WriteLine("Result was a draw");
            else
                Console.WriteLine("Player {0} won", gameResult == GameResult.PlayerOneWins ? "PlayerOne" : "PlayerTwo");

            completedGamesCount++;

            return gameResult;
        }
    }
}