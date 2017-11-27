﻿using System;
using NUnit.Framework;
using RockPaperScissors;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class TacticalComputerPlayerTests
    {

        [Test]
        public void FirstMoveIsARandomMove()
        {
            var rockCount = 0;
            var scisssorsCount = 0;
            var paperCount = 0;

            IPlayer player;

            for(int i = 0; i < 100; i++)
            {
                player = new TacticalComputerPlayer();

                player.GetPlayerMove();
                var lastMove = player.GetPlayerMove();

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

                //within the tacticalcomputer player constructor is a random number generator with a time dependant seed. 
                //Adding the millisecond between calling the constructor means the seed is different for each instances of player
                Thread.Sleep(1);
            }

            Assert.True(rockCount > 20);
            Assert.True(paperCount > 20);
            Assert.True(scisssorsCount > 20);

        }

        [Test]
        public void SecondAndThirdMovesAreTactical()
        {
            //execute this 100 times, since the results should never change

            for (int i = 0; i < 100; i++)
            {
                //plays the move that would have defeated it's last move

                TacticalComputerPlayer player = new TacticalComputerPlayer();

                //start first move as scissors
                player.Play(Move.Scissors);

                //scissors are defeated by rock
                Assert.AreEqual(Move.Rock, player.GetPlayerMove());

                //rock is defeated by paper
                Assert.AreEqual(Move.Paper, player.GetPlayerMove());

                // avoids race condition
                Thread.Sleep(1);
            }
        }

    }
}
