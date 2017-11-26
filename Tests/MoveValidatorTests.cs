using RockPaperScissors;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class MoveValidatorTests
    {
        [TestCase("s", true)]
        [TestCase("p", true)]
        [TestCase("r", true)]
        [TestCase("Scissors", true)]
        [TestCase("Paper", true)]
        [TestCase("Rock", true)]
        [TestCase("Martian", false)]
        [TestCase("", false)]
        public void ValidatesInput(string input, bool expectedValidity)
        {
            Assert.AreEqual(expectedValidity, MoveValidator.IsValid(input));
        }

        [TestCase("s", Move.Scissors)]
        [TestCase("p", Move.Paper)]
        [TestCase("r", Move.Rock)]
        [TestCase("Scissors", Move.Scissors)]
        [TestCase("Paper", Move.Paper)]
        [TestCase("Rock", Move.Rock)]
        public void ParsesCorrectly(string input, Move expected)
        {
            Assert.AreEqual(expected, MoveValidator.Parse(input));

            Assert.Throws<ArgumentOutOfRangeException>(() => { MoveValidator.Parse("Helicopter"); });
        }
    }
}
