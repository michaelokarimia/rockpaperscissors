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

            mockPlayerOne.SetupSequence(x => x.GetPlayerMove())
                .Returns(Move.Rock)
                .Returns(Move.Scissors)
                .Returns(Move.Scissors);

            mockPlayerTwo.SetupSequence(x => x.GetPlayerMove())
                .Returns(Move.Scissors)
                .Returns(Move.Paper)
                .Returns(Move.Paper);


            var gamesPlayed = new List<Game> {

                new Game(mockPlayerOne.Object, mockPlayerTwo.Object),
                new Game(mockPlayerOne.Object, mockPlayerTwo.Object),
                new Game(mockPlayerOne.Object, mockPlayerTwo.Object)
            };

            Assert.AreEqual(Result.PlayerOneWins, match.ComputeMatchResult(gamesPlayed));
        }

        [Test]
        public void PlayerTwoWinsTwoGamesAndMatch()
        {
          

            match = new RockPaperScissors.Match(mockPlayerOne.Object, mockPlayerTwo.Object);

            mockPlayerOne.SetupSequence(x => x.GetPlayerMove())
              .Returns(Move.Scissors)
              .Returns(Move.Paper)
              .Returns(Move.Rock);

            mockPlayerTwo.SetupSequence(x => x.GetPlayerMove())
                .Returns(Move.Rock)
                .Returns(Move.Rock)
                .Returns(Move.Paper);

            var gamesPlayed = new List<Game> {

                new Game(mockPlayerOne.Object, mockPlayerTwo.Object),
                new Game(mockPlayerOne.Object, mockPlayerTwo.Object),
                new Game(mockPlayerOne.Object, mockPlayerTwo.Object)
            };

            Assert.AreEqual(Result.PlayerTwoWins, match.ComputeMatchResult(gamesPlayed));
        }

        [Test]
        public void AllGamesDrawSoMatchIsADraw()
        {

            match = new RockPaperScissors.Match(mockPlayerOne.Object, mockPlayerTwo.Object);


            mockPlayerOne.SetupSequence(x => x.GetPlayerMove())
              .Returns(Move.Rock)
              .Returns(Move.Paper)
              .Returns(Move.Scissors);

            mockPlayerTwo.SetupSequence(x => x.GetPlayerMove())
                .Returns(Move.Rock)
                .Returns(Move.Paper)
                .Returns(Move.Scissors);

            var gamesPlayed = new List<Game> {

                new Game(mockPlayerOne.Object, mockPlayerTwo.Object),
                new Game(mockPlayerOne.Object, mockPlayerTwo.Object),
                new Game(mockPlayerOne.Object, mockPlayerTwo.Object)
            };

            Assert.AreEqual(Result.Draw, match.ComputeMatchResult(gamesPlayed));
        }
    }
}
