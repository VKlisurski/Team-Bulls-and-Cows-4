using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;

namespace BullsAndCows.Tests.GameNumberTests
{
    [TestClass]
    public class GameNumberTests
    {
        [TestMethod]
        public void GanerateRandomNumberValidTest()
        {
            int defaultNumberLength = 4;
            string number = GameEngine.Instance.NumberProvider.Generate(defaultNumberLength);

            Assert.AreEqual(GameEngine.Instance.NumberProvider.IsItValid(number, defaultNumberLength), true);
        }

        [TestMethod]
        public void GanerateRandomNumberWithInvalidLengthTest()
        {
            int defaultNumberLength = 4;
            string number = GameEngine.Instance.NumberProvider.Generate(5);

            Assert.IsFalse(GameEngine.Instance.NumberProvider.IsItValid(number, defaultNumberLength));
        }

        [TestMethod]
        public void ValidateEmptyNumberStringTest()
        {
            int defaultNumberLength = 5;

            Assert.AreEqual(GameEngine.Instance.NumberProvider.IsItValid("", defaultNumberLength), false);
        }

        [TestMethod]
        public void ValidateInvalidNumberStringTest()
        {
            int defaultNumberLength = 5;

            Assert.AreEqual(GameEngine.Instance.NumberProvider.IsItValid("d123d", defaultNumberLength), false);
        }
    }
}
