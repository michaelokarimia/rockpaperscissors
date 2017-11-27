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

        public Match(IPlayer playerOne, IPlayer playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
            MaxGamesInMatch = 3;
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
            return MaxGamesInMatch == completedGamesCount;
        }

        public MatchState Start()
        {
            MatchState state = MatchState.PlayerOneTurn;

            var p1WinCount = 0;
            var p2WinCount = 0;


            while (state != MatchState.MatchOver)
            {
                while (state == MatchState.PlayerOneTurn)
                {
                    var p1Move = playerOne.GetPlayerMove();

                    state = MatchState.PlayerTwoTurn;
                }

                while (state == MatchState.PlayerTwoTurn)
                {
                    var p2Move = playerTwo.GetPlayerMove();

                    state = MatchState.PlayerOneTurn;
                }

                var gameResult = PlayGame();

                if (gameResult == Result.PlayerOneWins)
                    p1WinCount++;
                if (gameResult == Result.PlayerTwoWins)
                    p2WinCount++;

                if (completedGamesCount == MaxGamesInMatch)
                {
                    state = MatchState.MatchOver;
                }
            }

            if (p1WinCount > p2WinCount)
                return MatchState.PlayerOneWins;
            else if (p2WinCount > p1WinCount)
                return MatchState.PlayerTwoWins;
            else
                return MatchState.Draw;

            
          
        }

        private Result PlayGame()
        {
            Console.WriteLine("Playing game");

            var game = new Game(playerOne, playerTwo);

            Console.WriteLine("Player One move was {0}", playerOne.LastMove);
            Console.WriteLine("Player Two move was {0}", playerTwo.LastMove);


            var gameResult = game.Play();

            Console.WriteLine("Game {0}:", completedGamesCount +1);

            if (gameResult == Result.Draw)
                Console.WriteLine("Result was a draw");
            else
                Console.WriteLine("Player {0} won", gameResult == Result.PlayerOneWins ? "PlayerOne" : "PlayerTwo");

            completedGamesCount++;

            return gameResult;
        }
    }
}