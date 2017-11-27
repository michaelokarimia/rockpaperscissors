using System.Collections.Generic;
using NUnit.Framework;
using RockPaperScissors;
using Moq;
namespace Tests
{
    [TestFixture]
    public class MatchTests
    {
        RockPaperScissors.Match match;
        private Mock<IPlayer> mockPlayerOne;
        private Mock<IPlayer> mockPlayerTwo;

        [SetUp]
        public void Setup()
        {
            mockPlayerOne = new Mock<IPlayer>();
            mockPlayerTwo = new Mock<IPlayer>();
        }

        [Test]
        public void PlayerOneWinsTwoGamesAndMatch()
        {
            match = new RockPaperScissors.Match(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);

            var gameOne = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Paper);

            var gameTwo = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Paper);

            var gameThree = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            var gamesPlayed = new List<Game> { gameOne, gameTwo, gameThree };

            Assert.AreEqual(Result.PlayerOneWins, match.ComputeMatchResult(gamesPlayed));
        }

        [Test]
        public void PlayerTwoWinsTwoGamesAndMatch()
        {
          

            match = new RockPaperScissors.Match(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);

            var gameOne = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Paper);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);

            var gameTwo = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Paper);

            var gameThree = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            var gamesPlayed = new List<Game> { gameOne, gameTwo, gameThree };

            Assert.AreEqual(Result.PlayerTwoWins, match.ComputeMatchResult(gamesPlayed));
        }

        [Test]
        public void AllGamesDrawSoMatchIsADraw()
        {

            match = new RockPaperScissors.Match(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);

            var gameOne = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Paper);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Paper);

            var gameTwo = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);

            var gameThree = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            var gamesPlayed = new List<Game> { gameOne, gameTwo, gameThree };

            Assert.AreEqual(Result.Draw, match.ComputeMatchResult(gamesPlayed));
        }

        [Test]
        public void IsMatchOverReturnsFalseWhenMidmatch()
        {
            match = new RockPaperScissors.Match(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);

            var gamesPlayed = new List<Game>() { new Game(mockPlayerOne.Object, mockPlayerTwo.Object) };

            match.ComputeMatchResult(gamesPlayed);

            Assert.False(match.IsGameOver());

        }

        [Test]
        public void IsMatchOverReturnsTrueAtEndOfMatch()
        {

            match = new RockPaperScissors.Match(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Scissors);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);

            var gameOne = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Paper);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);

            var gameTwo = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.Setup(x => x.GetPlayerMove()).Returns(Move.Rock);
            mockPlayerTwo.Setup(x => x.GetPlayerMove()).Returns(Move.Paper);

            var gameThree = new Game(mockPlayerOne.Object, mockPlayerTwo.Object);

            var gamesPlayed = new List<Game> { gameOne, gameTwo, gameThree };


            match.ComputeMatchResult(gamesPlayed);

            Assert.True(match.IsGameOver());

        }
    }
}
