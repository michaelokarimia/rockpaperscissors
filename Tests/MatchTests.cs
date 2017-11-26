using System.Collections.Generic;
using NUnit.Framework;
using RockPaperScissors;
namespace Tests
{
    [TestFixture]
    public class MatchTests
    {
        Match match;
        private IPlayer playerOne;
        private IPlayer playerTwo;

        [SetUp]
        public void Setup()
        {
            playerOne = new HumanPlayer();
            playerTwo = new HumanPlayer();

            match = new Match(playerOne, playerTwo);
        }

        [Test]
        public void PlayerOneWinsTwoGamesAndMatch()
        {
            var gameOne = new Game(playerOne.Play(Move.Rock), playerTwo.Play(Move.Scissors));
            var gameTwo = new Game(playerOne.Play(Move.Scissors), playerTwo.Play(Move.Paper));
            var gameThree = new Game(playerOne.Play(Move.Paper), playerTwo.Play(Move.Rock));

            var gamesPlayed = new List<Game> { gameOne, gameTwo, gameThree };

            Assert.AreEqual(Result.PlayerOneWins, match.ComputeMatchResult(gamesPlayed));
        }

        [Test]
        public void PlayerTwoWinsTwoGamesAndMatch()
        {

            var gameOne = new Game(playerOne.Play(Move.Scissors), playerTwo.Play(Move.Rock));
            var gameTwo = new Game(playerOne.Play(Move.Paper), playerTwo.Play(Move.Rock));
            var gameThree = new Game(playerOne.Play(Move.Rock), playerTwo.Play(Move.Paper));

            var gamesPlayed = new List<Game> { gameOne, gameTwo, gameThree };

            Assert.AreEqual(Result.PlayerTwoWins, match.ComputeMatchResult(gamesPlayed));
        }

        [Test]
        public void AllGamesDrawSoMatchIsADraw()
        {
            var gameOne = new Game(playerOne.Play(Move.Scissors), playerTwo.Play(Move.Scissors));
            var gameTwo = new Game(playerOne.Play(Move.Paper), playerTwo.Play(Move.Paper));
            var gameThree = new Game(playerOne.Play(Move.Rock), playerTwo.Play(Move.Rock));

            var gamesPlayed = new List<Game> { gameOne, gameTwo, gameThree };

            Assert.AreEqual(Result.Draw, match.ComputeMatchResult(gamesPlayed));
        }

        [Test]
        public void IsMatchOverReturnsFalseWhenMidmatch()
        {
            var gamesPlayed = new List<Game>() { new Game(playerOne.Play(Move.Scissors), playerTwo.Play(Move.Scissors)) };

            match.ComputeMatchResult(gamesPlayed);

            Assert.False(match.IsGameOver());

        }

        [Test]
        public void IsMatchOverReturnsTrueAtEndOfMatch()
        {
            var gamesPlayed = new List<Game>()
            { new Game(playerOne.Play(Move.Scissors), playerTwo.Play(Move.Scissors)),
                new Game(playerOne.Play(Move.Scissors), playerTwo.Play(Move.Paper)),
                new Game(playerOne.Play(Move.Paper), playerTwo.Play(Move.Rock))
            };


            match.ComputeMatchResult(gamesPlayed);

            Assert.True(match.IsGameOver());

        }
    }
}
