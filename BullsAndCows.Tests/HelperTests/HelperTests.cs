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

            Assert.AreEqual("You are not allowed to cheat anymore!", GameEngine.Instance.Helper.GetHelp("1111"))
            ;
        }

        [TestMethod]
        public void GetHelpWithFiveCheatsUsedTest()
        {
            GameEngine.Instance.Helper.Cheats = 5;

            Assert.AreEqual("You are not allowed to cheat anymore!", GameEngine.Instance.Helper.GetHelp("1111"))
            ;
        }

        [TestMethod]
        public void GetHelpWithOneCheatsUsedTest()
        {
            GameEngine.Instance.Helper.Cheats = 1;
            GameEngine.Instance.Helper.GetHelp("1111");

            Assert.AreEqual(2, GameEngine.Instance.Helper.Cheats);
            ;
        }
    }
}
