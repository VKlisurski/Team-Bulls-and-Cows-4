using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;

namespace BullsAndCows.Tests.Strategy_Tests
{
    [TestClass]
    public class GameStrategyTests
    {
        [TestMethod]
        public void BullsAndCowsStrategyNoMatch()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "5067";
            const int ExpectedBulls = 0;
            const int ExpectedCows = 0;
            int bulls = 0;
            int cows = 0;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            strategy.ExecuteStrategy(PlayerInput, GeneratedNumber, out bulls, out cows);

            Assert.AreEqual(ExpectedBulls, bulls, "The result bulls should be {0}, but it is {1}", ExpectedBulls, bulls);
            Assert.AreEqual(ExpectedCows, cows, "The result cows should be {0}, but it is {1}", ExpectedCows, cows);
        }

        [TestMethod]
        public void BullsAndCowsStrategyTestBulls()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "0351";
            const int ExpectedBulls = 1;
            int bulls = 0;
            int cows = 0;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            strategy.ExecuteStrategy(PlayerInput, GeneratedNumber, out bulls, out cows);

            Assert.AreEqual(ExpectedBulls, bulls, "The result bulls should be {0}, but it is {1}", ExpectedBulls, bulls);
        }

        [TestMethod]
        public void BullsAndCowsStrategyTestCows()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "0351";
            const int ExpectedCows = 1;
            int bulls = 0;
            int cows = 0;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            strategy.ExecuteStrategy(PlayerInput, GeneratedNumber, out bulls, out cows);

            Assert.AreEqual(ExpectedCows, cows, "The result cows should be {0}, but it is {1}", ExpectedCows, cows);
        }

        [TestMethod]
        public void BullsAndCowsStrategyTestAllCows()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "3421";
            const int ExpectedCows = 4;
            int bulls = 0;
            int cows = 0;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            strategy.ExecuteStrategy(PlayerInput, GeneratedNumber, out bulls, out cows);

            Assert.AreEqual(ExpectedCows, cows, "The result cows should be {0}, but it is {1}", ExpectedCows, cows);
        }

        [TestMethod]
        public void BullsAndCowsStrategyTestAllBulls()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "1342";
            const int ExpectedBulls = 4;
            int bulls = 0;
            int cows = 0;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            strategy.ExecuteStrategy(PlayerInput, GeneratedNumber, out bulls, out cows);

            Assert.AreEqual(ExpectedBulls, bulls, "The result bulls should be {0}, but it is {1}", ExpectedBulls, bulls);
        }
    }
}
