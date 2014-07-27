using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;

namespace BullsAndCows.Tests.HelperTests
{
    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void GetHelpWithFourCheatsUsedTest()
        {
            GameEngine.Instance.Helper.Cheats = 4;

            Assert.AreEqual("You are not allowed to cheat anymore!", GameEngine.Instance.Helper.GetHelp("1111"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The player can only have up to four cheats in a game.")]
        public void GetHelpWithFiveCheatsUsedTest()
        {
            GameEngine.Instance.Helper.Cheats = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The player cannont have a negative amount of cheats in a game.")]
        public void ShouldNotAllowNegativeAmountOfCheats()
        {
            GameEngine.Instance.Helper.Cheats = -3;
        }

        [TestMethod]
        public void GetHelpWithOneCheatsUsedTest()
        {
            GameEngine.Instance.Helper.Cheats = 1;
            GameEngine.Instance.Helper.GetHelp("1111");

            Assert.AreEqual(2, GameEngine.Instance.Helper.Cheats);
        }
    }
}
