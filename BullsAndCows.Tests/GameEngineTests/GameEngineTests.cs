using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;
using System.IO;

namespace BullsAndCows.Tests.GameEngineTests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void GetScoreBoardTest()
        {
            Assert.IsInstanceOfType(GameEngine.Instance.LeaderBoard, typeof(LeaderBoard<Player>));
        }

        [TestMethod]
        public void ExitGameTest()
        {
            GameEngine.Instance.Exit();
            Assert.AreEqual(false, GameEngine.Instance.GameOn);
        }

        [TestMethod]
        public void ShouldGetCorrectHelp()
        {
            GameNumberProvider numberProvider = new GameNumberProvider();
            string help = GameEngine.Instance.GetHelp();
            GameEngine.Instance.Helper.Cheats -= 1;

            Assert.AreEqual(help, GameEngine.Instance.GetHelp());
        }

        [TestMethod]
        public void ShouldProperlyResetGameEngineAttemptsAndCheats()
        {
            GameEngine.Instance.Attempts += 1;
            GameEngine.Instance.Helper.Cheats += 1;

            GameEngine.Instance.Restart();

            int expectedAttempts = 0;
            int expectedCheats = 0;

            Assert.AreEqual(expectedAttempts, GameEngine.Instance.Attempts);
            Assert.AreEqual(expectedCheats, GameEngine.Instance.Helper.Cheats);
        }

        [TestMethod]
        public void ShouldGetCorrectAttempts()
        {
            int expectedAttempts = 0;

            Assert.AreEqual(expectedAttempts, GameEngine.Instance.Attempts);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SettingIncorrectAttemptsShouldThrowException()
        {
            GameEngine.Instance.Attempts = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SettingNullHelperShouldThrowException()
        {
            GameEngine.Instance.Helper = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SettingNullInputOutputShouldThrowException()
        {
            GameEngine.Instance.InputOutput = null;
        }

        [TestMethod]
        public void ShouldSetCorrectInputOutput()
        {
            InputOutput expectedInputoutput = new InputOutput();

            GameEngine.Instance.InputOutput = expectedInputoutput;

            Assert.AreEqual(expectedInputoutput, GameEngine.Instance.InputOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SettingNullMessageDispatcherShouldThrowException()
        {
            GameEngine.Instance.MessageDispatcher = null;
        }

        [TestMethod]
        public void ShouldSetCorrectMessageDispatcher()
        {
            MessageDispatcher expectedDispatcher = new MessageDispatcher();

            GameEngine.Instance.MessageDispatcher = expectedDispatcher;

            Assert.AreEqual(expectedDispatcher, GameEngine.Instance.MessageDispatcher);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SettingNullNumberProviderShouldThrowException()
        {
            GameEngine.Instance.NumberProvider = null;
        }

        [TestMethod]
        public void ShouldSetCorrectNumberProvider()
        {
            GameNumberProvider expectedProvider = new GameNumberProvider();

            GameEngine.Instance.NumberProvider = expectedProvider;

            Assert.AreEqual(expectedProvider, GameEngine.Instance.NumberProvider);
        }
    }
}