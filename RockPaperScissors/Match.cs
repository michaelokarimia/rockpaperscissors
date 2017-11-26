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

        public void Start()
        {

            Console.WriteLine("Select (r)ock, (p)aper or (s)cissors as your move");

            var inputString = Console.ReadLine().ToLowerInvariant().Trim();

            playerOne = new HumanPlayer();

            if (MoveValidator.IsValid(inputString))
                playerOne.Play(MoveValidator.Parse(inputString));
            else
                Console.WriteLine("Invalid input, Select(r)ock, (p)aper or(s)cissors as your move");

            Console.WriteLine("Select (r)ock, (p)aper or (s)cissors as your move");

            inputString = Console.ReadLine().ToLowerInvariant().Trim();

            playerTwo = new HumanPlayer();

            if (MoveValidator.IsValid(inputString))
                playerTwo.Play(MoveValidator.Parse(inputString));
            else
                Console.WriteLine("Invalid input, Select(r)ock, (p)aper or(s)cissors as your move");


            var gameCount = 0;

            Console.WriteLine("Playing game");

            var firstGame = new Game(playerOne, playerTwo);

            var firstResult = firstGame.Play();
            gameCount++;

            Console.WriteLine("Game {0}:", gameCount);

            if (firstResult == Result.Draw)
                Console.WriteLine("Result was a draw");
            else
                Console.WriteLine("Player {0} won", firstResult == Result.PlayerOneWins ? "PlayerOne" : "PlayerTwo");
        }
    }
}