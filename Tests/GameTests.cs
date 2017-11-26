using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RockPaperScissors;

namespace Tests
{
    [TestFixture]
    public class GameTests
    {

        [Test]
        public void Player1WinsWithRockVsScissors()
        {

            Player player1 = new Player();
            Player player2 = new Player();
            var round = new Round(player1.Play(Move.Rock), player2.Play(Move.Scissors));

            round.Play();

            Assert.True(round.IsPlayer1Wins());
        }
    }
}
