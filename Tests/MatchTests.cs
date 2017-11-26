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
    public class MatchTests
    {
        Match match; 


        [Test]
        public void PlayerOneWinsTwoGamesAndMatch()
        {
            var playerOne = new Player();
            var playerTwo = new Player();

            match = new Match(playerOne, playerTwo);

            Game gameOne = new Game(playerOne.Play(Move.Rock), playerTwo.Play(Move.Scissors));
            Game gameTwo = new Game(playerOne.Play(Move.Scissors), playerTwo.Play(Move.Paper));
            Game gameThree = new Game(playerOne.Play(Move.Paper), playerTwo.Play(Move.Rock));

            var gamesPlayed = new List<Game> { gameOne, gameTwo, gameThree };

           


            Assert.AreEqual(Result.PlayerOneWins, match.PlayGames(gamesPlayed));
        }
    }
}
