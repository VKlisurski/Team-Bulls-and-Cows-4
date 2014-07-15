using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;
using System.Collections;
using System.Collections.Generic;

namespace BullsAndCows.Tests.LeaderBoardTests
{
    [TestClass]
    public class LeaderBoardTests
    {
        [TestMethod]
        public void DefaultCount()
        {
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>();

            int resultCount = testLeaderBoard.Count;

            Assert.AreEqual(0, resultCount, "The default leaderBoard count should be 0");
        }
        
        [TestMethod]
        public void SetMaxNumberOfItems()
        {
            int expectedMaxNum = 5;

            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>(expectedMaxNum);

            int maxNumOfItemsResult = testLeaderBoard.MaxNumberOfItems;

            Assert.AreEqual(expectedMaxNum, maxNumOfItemsResult, 
                "The expected Maximum Number of Items is {0} and the result is {1}", expectedMaxNum, maxNumOfItemsResult);
        }

        [TestMethod]
        public void TestAddOnePerson()
        {
            Player testPlayer = new Player("Viktor", 3);
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>();

            testLeaderBoard.Add(testPlayer);
            int output = testLeaderBoard.Count;

            Assert.AreEqual(1, output, "The expected output should be 1, but it is {0}", output);
        }

        [TestMethod]
        public void TestAddMoreThanMaximumPeople()
        {
            int maxItems = 3;
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>(maxItems);

            int peopleAddedCount = maxItems + 1;
            for (int i = 0; i < peopleAddedCount; i++)
            {
                string playerName = "Player" + i;

                testLeaderBoard.Add(new Player(playerName, i));
            }

            int result = testLeaderBoard.Count;
            Assert.AreNotEqual(peopleAddedCount, result,
                "The people added should be {0} and the result is {1}", maxItems, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OutOfRangeMaximumPeople()
        {

            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>(0);
        }

        [TestMethod]
        public void TestMoveNextOnce()
        {
            Player viktor = new Player("Viktor", 3);
            Player niki = new Player("Niki", 2);
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>();

            testLeaderBoard.Add(viktor);
            testLeaderBoard.Add(niki);

            testLeaderBoard.MoveNext();
            string resultPlayerName = testLeaderBoard.Current.Name;

            Assert.AreSame("Niki", resultPlayerName,
                "The expected result should be Niki, because he has less attempts, but the output is {0}",
                resultPlayerName);
        }

        [TestMethod]
        public void TestMoveNextManyTimes()
        {
            Player viktor = new Player("Viktor", 3);
            Player niki = new Player("Niki", 2);
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>();

            testLeaderBoard.Add(viktor);
            testLeaderBoard.Add(niki);

            testLeaderBoard.MoveNext();
            testLeaderBoard.MoveNext();
            testLeaderBoard.MoveNext();
            string resultPlayerName = testLeaderBoard.Current.Name;

            Assert.AreSame("Viktor", resultPlayerName,
                "The expected result should be Viktor, because he has less attempts, but the output is {0}",
                resultPlayerName);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestCurrent()
        {
            Player viktor = new Player("Viktor", 3);
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>();

            testLeaderBoard.Add(viktor);

            Player throwExceptionExpected = testLeaderBoard.Current;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestDispose()
        {
            Player viktor = new Player("Viktor", 3);
            Player niki = new Player("Niki", 2);
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>();

            testLeaderBoard.Add(viktor);
            testLeaderBoard.Add(niki);

            testLeaderBoard.MoveNext();
            testLeaderBoard.Dispose();
            Player throwExceptionExpected = testLeaderBoard.Current;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestReset()
        {
            Player viktor = new Player("Viktor", 3);
            Player niki = new Player("Niki", 2);
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>();

            testLeaderBoard.Add(viktor);
            testLeaderBoard.Add(niki);

            testLeaderBoard.MoveNext();
            testLeaderBoard.Reset();
            Player throwExceptionExpected = testLeaderBoard.Current;
        }

        [TestMethod]
        public void GetEnumeratorTest()
        {
            LeaderBoard<Player> testLeaderBoard = new LeaderBoard<Player>();

            IEnumerator<Player> type = testLeaderBoard.GetEnumerator() as IEnumerator<Player>;

            Assert.AreNotSame(null, type, "The generated is not type if IEnumerable");
        }
    }
}
