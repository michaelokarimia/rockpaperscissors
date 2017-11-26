using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RoundTests
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

            Player player1 = new Player();
            Player player2 = new Player();
            var round = new Round(player1.Play(p1Move), player2.Play(p2Move));

            Assert.AreEqual(expectedResult, round.Play());

        }

    }
}
