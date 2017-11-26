using NUnit.Framework;
using RockPaperScissors;

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

            IPlayer player1 = new HumanPlayer();
            IPlayer player2 = new HumanPlayer();
            var round = new Game(player1.Play(p1Move), player2.Play(p2Move));

            Assert.AreEqual(expectedResult, round.Play());

        }

    }
}
