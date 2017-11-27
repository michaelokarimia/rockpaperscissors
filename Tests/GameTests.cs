using NUnit.Framework;
using RockPaperScissors;
using Moq;

namespace Tests
{
    [TestFixture]
    public class GameTests
    {
        


        [TestCase(Move.Rock, Move.Scissors, Result.PlayerOneWins)]
        [TestCase(Move.Rock, Move.Paper, Result.PlayerTwoWins)]
        [TestCase(Move.Rock, Move.Rock, Result.Draw)]

        [TestCase(Move.Paper, Move.Rock, Result.PlayerOneWins)]
        [TestCase(Move.Paper, Move.Scissors, Result.PlayerTwoWins)]
        [TestCase(Move.Paper, Move.Paper, Result.Draw)]

        [TestCase(Move.Scissors, Move.Paper, Result.PlayerOneWins)]
        [TestCase(Move.Scissors, Move.Rock, Result.PlayerTwoWins)]
        [TestCase(Move.Scissors, Move.Scissors, Result.Draw)]
        public void PlayerRoundRetunsExpectedResults(Move p1Move, Move p2Move, Result expectedResult)
        {
            Mock<IPlayer> player1Mock = new Mock<IPlayer>();
            Mock<IPlayer> player2Mock = new Mock<IPlayer>();

            player1Mock.Setup(x => x.GetPlayerMove()).Returns(p1Move);
            player2Mock.Setup(x => x.GetPlayerMove()).Returns(p2Move);

            var player1 = player1Mock.Object;
            var player2 = player2Mock.Object;


            var round = new Game(player1, player2);

            Assert.AreEqual(expectedResult, round.Play());

        }

    }
}
