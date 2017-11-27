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
    public class RandomComputerPlayerTests
    {
        IPlayer player;

        [Test]
        public void ReturnsARandomMove()
        {
            player = new RandomComputerPlayer();

            player.GetPlayerMove();

            var lastMove = player.LastMove();

            var rockCount = 0;
            var scisssorsCount = 0;
            var paperCount = 0;

            for(int i = 0; i < 100; i++)
            {
                player.GetPlayerMove();
                lastMove = player.LastMove();

                switch (lastMove)
                {
                    case Move.Rock:
                        rockCount++;
                        break;
                    case Move.Paper:
                        paperCount++;
                        break;
                    case Move.Scissors:
                        scisssorsCount++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Should only be rock, paper or scissors");
                }

            }

            Assert.True(rockCount > 20);
            Assert.True(paperCount > 20);
            Assert.True(scisssorsCount > 20);

        }
    }
}
