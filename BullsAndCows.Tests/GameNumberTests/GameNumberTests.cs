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
            string number = GameNumber.Generate(defaultNumberLength);

            Assert.AreEqual(GameNumber.IsItValid(number, defaultNumberLength), true);
        }

        [TestMethod]
        public void GanerateRandomNumberWithInvalidLengthTest()
        {
            int defaultNumberLength = 4;
            string number = GameNumber.Generate(5);

            Assert.IsFalse(GameNumber.IsItValid(number, defaultNumberLength));
        }

        [TestMethod]
        public void ValidateEmptyNumberStringTest()
        {
            int defaultNumberLength = 5;

            Assert.AreEqual(GameNumber.IsItValid("", defaultNumberLength), false);
        }

        [TestMethod]
        public void ValidateInvalidNumberStringTest()
        {
            int defaultNumberLength = 5;

            Assert.AreEqual(GameNumber.IsItValid("d123d", defaultNumberLength), false);
        }
    }
}
