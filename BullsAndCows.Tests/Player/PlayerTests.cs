using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;

namespace BullsAndCows.Tests.Player_Attempts
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNegativeAttempts()
        {
            Player testPlayer = new Player("Viktor", -2);
        }

        [TestMethod]
        public void TestAttemptsChange()
        {
            Player testPlayer = new Player("Viktor", 2);
            testPlayer.Attempts = 4;
            int expectedResult = 4;
            int output = testPlayer.Attempts;

            Assert.AreEqual(expectedResult, output, 
                "The expected attempts result was {0}, but the output was {1}", expectedResult, output);
        }

        [TestMethod]
        public void NameTests()
        {
            Player testPlayer = new Player("Viktor", 2);

            Assert.AreSame("Viktor", testPlayer.Name, "The player names are different");
        }

        [TestMethod]
        public void ChangeNameTests()
        {
            Player testPlayer = new Player("Viktor", 2);

            testPlayer.Name = "Gosho";

            Assert.AreSame("Gosho", testPlayer.Name, "The player names are different");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullNameTests()
        {
            Player testPlayer = new Player("", 2);

            Assert.AreSame("Viktor", testPlayer.Name, "The player names are different");
        }

        [TestMethod]
        public void CompareToSamePlayersTest()
        {
            Player firstPlayer = new Player("Viktor", 3);
            Player secondPlayer = new Player("Gosho", 3);

            int result = firstPlayer.CompareTo(secondPlayer);

            Assert.AreEqual(0, result, "The players attempts should be equal, buit they are not");
        }

        [TestMethod]
        public void CompareToDifferentPlayersTest()
        {
            Player firstPlayer = new Player("Viktor", 3);
            Player secondPlayer = new Player("Gosho", 2);

            int result = firstPlayer.CompareTo(secondPlayer);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToNull()
        {
            Player firstPlayer = new Player("Viktor", 3);

            int result = firstPlayer.CompareTo(null);
        }
    }
}
