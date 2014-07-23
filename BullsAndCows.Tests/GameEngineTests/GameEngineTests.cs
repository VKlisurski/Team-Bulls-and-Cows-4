using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;

namespace BullsAndCows.Tests.GameEngineTests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void GetScoreBoardTest()
        {
            Assert.IsInstanceOfType(GameEngine.Instance.ScoreBoard, typeof(LeaderBoard<Player>));
        }

        [TestMethod]
        public void ExitGameTest()
        {
            GameEngine.Instance.Exit();
            Assert.AreEqual(false, GameEngine.Instance.GameOn);
        }
    }
}
