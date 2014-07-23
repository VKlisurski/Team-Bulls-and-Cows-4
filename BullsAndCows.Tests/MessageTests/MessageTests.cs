using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;
using System.Text;

namespace BullsAndCows.Tests.MessageTests
{
    [TestClass]
    public class MessageTests
    {
        [TestMethod]
        public void GoodByeTest()
        {
            Assert.AreEqual("Good bye!", GameEngine.Instance.MessageDispatcher.GetGoodbyeMessage(), "Wrong goodbye message!");
        }

        [TestMethod]
        public void InvalidCommandTest()
        {
            Assert.AreEqual("Invalid guess or command!", GameEngine.Instance.MessageDispatcher.GetInvalidCommandMessage(), "Wrong invalid command message!");
        }

        [TestMethod]
        public void NoCheatersTest()
        {
            Assert.AreEqual("Cheaters are not allowed to enter the top scoreboard.", GameEngine.Instance.MessageDispatcher.GetNoCheatersMessage(), "Wrong message that disallows cheaters on the scoreboard!");
        }

        [TestMethod]
        public void EnterNameTest()
        {
            Assert.AreEqual("Please enter your name for the top scoreboard: ", GameEngine.Instance.MessageDispatcher.GetEnterNameMessage(), "Wrong message that asks players to enter name for the scoreboard!");
        }

        [TestMethod]
        public void EnterCommandTest()
        {
            Assert.AreEqual("Enter your guess or command: ", GameEngine.Instance.MessageDispatcher.GetEnterCommandMessage(), "Wrong message that asks players to enter command!");
        }

        [TestMethod]
        public void GetScoreBoardWithEmptyLeaderBoardTest()
        {
            LeaderBoard<Player> leaderboard = new LeaderBoard<Player>();
            Assert.AreEqual("Top scoreboard is empty.", GameEngine.Instance.MessageDispatcher.GetScoreBoard(leaderboard), "Wrong message when empty scoreboard is passed as argument!");
        }

        [TestMethod]
        public void GetScoreBoardWithOnePlayerAndOnGuessTest()
        {
            LeaderBoard<Player> leaderboard = new LeaderBoard<Player>();
            Player player = new Player("Pesho", 1);

            leaderboard.Add(player);

            Assert.AreEqual("Scoreboard:\n1. Pesho --> 1 guess\n", GameEngine.Instance.MessageDispatcher.GetScoreBoard(leaderboard));
        }

        [TestMethod]
        public void GetScoreBoardWithOnePlayerAndFiveGuessesTest()
        {
            LeaderBoard<Player> leaderboard = new LeaderBoard<Player>();
            Player player = new Player("Pesho", 5);

            leaderboard.Add(player);

            Assert.AreEqual("Scoreboard:\n1. Pesho --> 5 guesses\n", GameEngine.Instance.MessageDispatcher.GetScoreBoard(leaderboard));
        }

        [TestMethod]
        public void GetScoreBoardWithThreePlayersAndMultipleGuessesTest()
        {
            LeaderBoard<Player> leaderboard = new LeaderBoard<Player>();
            Player player1 = new Player("Pesho", 5);
            Player player2 = new Player("Gosho", 1);
            Player player3 = new Player("Hristo", 3);

            leaderboard.Add(player1);
            leaderboard.Add(player2);
            leaderboard.Add(player3);

            Assert.AreEqual("Scoreboard:\n1. Gosho --> 1 guess\n2. Hristo --> 3 guesses\n3. Pesho --> 5 guesses\n", GameEngine.Instance.MessageDispatcher.GetScoreBoard(leaderboard));
        }

        [TestMethod]
        public void CongratulateWithoutCheatsAndOneAttemptTest()
        {
            Helper helper = new Helper();
            int attempts = 1;

            Assert.AreEqual("Congratulations!\nYou guessed the secret number in 1 attempt.", GameEngine.Instance.MessageDispatcher.GetCongatulationsMessage(helper, attempts));
        }

        [TestMethod]
        public void CongratulateWithoutCheatsAndFiveAttemptsTest()
        {
            Helper helper = new Helper();
            int attempts = 5;

            Assert.AreEqual("Congratulations!\nYou guessed the secret number in 5 attempts.", GameEngine.Instance.MessageDispatcher.GetCongatulationsMessage(helper, attempts));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The number of attemps to win the game cannot be zero or negative integer")]
        public void CongratulateWithNegativeAttemptsTest()
        {
            Helper helper = new Helper();
            int attempts = -5;

            GameEngine.Instance.MessageDispatcher.GetCongatulationsMessage(helper, attempts);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The number of attemps to win the game cannot be zero or negative integer")]
        public void CongratulateWithZeroAttemptsTest()
        {
            Helper helper = new Helper();
            int attempts = 0;

            GameEngine.Instance.MessageDispatcher.GetCongatulationsMessage(helper, attempts);
        }

        [TestMethod]
        public void CongratulateWithOneCheatAndOneAttemptTest()
        {
            Helper helper = new Helper();
            helper.Cheats = 1;
            int attempts = 1;

            Assert.AreEqual("Congratulations!\nYou guessed the secret number in 1 attempt and 1 cheat.", GameEngine.Instance.MessageDispatcher.GetCongatulationsMessage(helper, attempts));
        }

        [TestMethod]
        public void CongratulateWithSeveralCheatAndSeveralAttemptsTest()
        {
            Helper helper = new Helper();
            helper.Cheats = 4;
            int attempts = 3;

            Assert.AreEqual("Congratulations!\nYou guessed the secret number in 3 attempts and 4 cheats.", GameEngine.Instance.MessageDispatcher.GetCongatulationsMessage(helper, attempts));
        }

        [TestMethod]
        public void WrongNumberTest()
        {
            int bullsCount = 3;
            int cowsCount = 2;

            Assert.AreEqual("Wrong number! Bulls: 3, Cows: 2", GameEngine.Instance.MessageDispatcher.GetWrongNumberMessage(bullsCount, cowsCount));
        }

        [TestMethod]
        public void WelcomeMessageTest()
        {
            string expectedResult = "Welcome to “Bulls and Cows” game.\n\nPlease try to guess my secret 4-digit number.\nUse:\n'top' to view the top scoreboard\n'restart' to start a new game\n'help' to cheat\n'exit' to quit the game.\n";

            Assert.AreEqual(expectedResult.ToString(), GameEngine.Instance.MessageDispatcher.GetWelcomeMessage());
        }
    }
}