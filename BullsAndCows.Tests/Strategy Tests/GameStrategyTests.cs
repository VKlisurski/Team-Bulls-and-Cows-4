using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;
using BullsAndCowsGame.Contracts;

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

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            GuessResult guessResult = strategy.ExecuteStrategy(PlayerInput, GeneratedNumber);

            Assert.AreEqual(ExpectedBulls, guessResult.Bulls, "The result bulls should be {0}, but it is {1}", ExpectedBulls, guessResult.Bulls);
            Assert.AreEqual(ExpectedCows, guessResult.Cows, "The result cows should be {0}, but it is {1}", ExpectedCows, guessResult.Cows);
        }

        [TestMethod]
        public void BullsAndCowsStrategyTestBulls()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "0351";
            const int ExpectedBulls = 1;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            GuessResult guessResult = strategy.ExecuteStrategy(PlayerInput, GeneratedNumber);

            Assert.AreEqual(ExpectedBulls, guessResult.Bulls, "The result bulls should be {0}, but it is {1}", ExpectedBulls, guessResult.Bulls);
        }

        [TestMethod]
        public void BullsAndCowsStrategyTestCows()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "0351";
            const int ExpectedCows = 1;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            GuessResult guessResult = strategy.ExecuteStrategy(PlayerInput, GeneratedNumber);

            Assert.AreEqual(ExpectedCows, guessResult.Cows, "The result cows should be {0}, but it is {1}", ExpectedCows, guessResult.Cows);
        }

        [TestMethod]
        public void BullsAndCowsStrategyTestAllCows()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "3421";
            const int ExpectedCows = 4;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            GuessResult guessResult = strategy.ExecuteStrategy(PlayerInput, GeneratedNumber);

            Assert.AreEqual(ExpectedCows, guessResult.Cows, "The result cows should be {0}, but it is {1}", ExpectedCows, guessResult.Cows);
        }

        [TestMethod]
        public void BullsAndCowsStrategyTestAllBulls()
        {
            const string PlayerInput = "1342";
            const string GeneratedNumber = "1342";
            const int ExpectedBulls = 4;

            ICalculateBullsAndCowsStrategy strategy = new NormalCalculateBullsAndCowsStrategy();

            GuessResult guessResult = strategy.ExecuteStrategy(PlayerInput, GeneratedNumber);

            Assert.AreEqual(ExpectedBulls, guessResult.Bulls, "The result bulls should be {0}, but it is {1}", ExpectedBulls, guessResult.Bulls);
        }
    }
}