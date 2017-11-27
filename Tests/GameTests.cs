using NUnit.Framework;
using RockPaperScissors;
using Moq;

namespace Tests
{
    [TestFixture]
    public class GameTests
    {
        


        [TestCase(Move.Rock, Move.Scissors, GameResult.PlayerOneWins)]
        [TestCase(Move.Rock, Move.Paper, GameResult.PlayerTwoWins)]
        [TestCase(Move.Rock, Move.Rock, GameResult.Draw)]

        [TestCase(Move.Paper, Move.Rock, GameResult.PlayerOneWins)]
        [TestCase(Move.Paper, Move.Scissors, GameResult.PlayerTwoWins)]
        [TestCase(Move.Paper, Move.Paper, GameResult.Draw)]

        [TestCase(Move.Scissors, Move.Paper, GameResult.PlayerOneWins)]
        [TestCase(Move.Scissors, Move.Rock, GameResult.PlayerTwoWins)]
        [TestCase(Move.Scissors, Move.Scissors, GameResult.Draw)]
        public void PlayerRoundRetunsExpectedResults(Move p1Move, Move p2Move, GameResult expectedResult)
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
