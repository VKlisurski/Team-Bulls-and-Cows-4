using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;
using System.IO;

namespace BullsAndCows.Tests.CommandTests
{
    [TestClass]
    public class CommandTests
    {
        private GameEngine engine = GameEngine.Instance;

        [TestMethod]
        public void TopCommandTest()
        {
            FactoryMethod factory = new CommandCreator();

            Assert.IsInstanceOfType(factory.Create("top", GameEngine.Instance), typeof(CommandTop));
        }

        [TestMethod]
        public void StartNewGameCommandTest()
        {
            FactoryMethod factory = new CommandCreator();

            Assert.IsInstanceOfType(factory.Create("restart", GameEngine.Instance), typeof(CommandRestart));
        }

        [TestMethod]
        public void HelpCommandTest()
        {
            FactoryMethod factory = new CommandCreator();

            Assert.IsInstanceOfType(factory.Create("help", GameEngine.Instance), typeof(CommandHelp));
        }

        [TestMethod]
        public void HelpCommandShouldReturnCorrectHelp()
        {
            FactoryMethod factory = new CommandCreator();
            string helpCommandName = "help";

            Command helpCommand = factory.Create(helpCommandName, GameEngine.Instance);

            string expectedHelp = GameEngine.Instance.GetHelp() + "\r\n";
            GameEngine.Instance.Helper.Cheats -= 1;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                helpCommand.Execute(GameEngine.Instance.InputOutput);

                Assert.AreEqual(expectedHelp, sw.ToString());

                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ExitCommandTest()
        {
            FactoryMethod factory = new CommandCreator();

            Assert.IsInstanceOfType(factory.Create("exit", GameEngine.Instance), typeof(CommandExit));
        }

        [TestMethod]
        public void OtherCommandTest()
        {
            FactoryMethod factory = new CommandCreator();

            Assert.IsInstanceOfType(factory.Create("asdasf", GameEngine.Instance), typeof(CommandOther));
        }

        [TestMethod]
        public void ShouldGetInvalidCommandMessage()
        {
            FactoryMethod factory = new CommandCreator();

            string invalidCommandName = "invalid command string";
            Command otherCommand = factory.Create(invalidCommandName, GameEngine.Instance);
            string expectedMessage = "Invalid guess or command!\r\n";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                otherCommand.Execute(GameEngine.Instance.InputOutput);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());

                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ShouldGetGoodByeMessage()
        {
            FactoryMethod factory = new CommandCreator();

            string exitCommandName = "exit";
            Command otherCommand = factory.Create(exitCommandName, GameEngine.Instance);
            string expectedMessage = "Good bye!\r\n";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                otherCommand.Execute(GameEngine.Instance.InputOutput);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());

                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        [TestMethod]
        public void ShouldGetOnePlayerInLeaderBoardMessage()
        {
            FactoryMethod factory = new CommandCreator();

            string topCommandName = "top";
            Command topCommand = factory.Create(topCommandName, GameEngine.Instance);
            string expectedMessage = "Scoreboard:\n1. Gosho --> 1 guess\n2. Hristo --> 3 guesses\n3. Pesho --> 5 guesses\n\r\n";
            
            Player player1 = new Player("Pesho", 5);
            Player player2 = new Player("Gosho", 1);
            Player player3 = new Player("Hristo", 3);

            GameEngine.Instance.LeaderBoard.Add(player1);
            GameEngine.Instance.LeaderBoard.Add(player2);
            GameEngine.Instance.LeaderBoard.Add(player3);
            
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                topCommand.Execute(GameEngine.Instance.InputOutput);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());

                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }

        /*
        [TestMethod]
        public void ShouldGetWelcomeMessage()
        {
            FactoryMethod factory = new CommandCreator();

            string restartCommandName = "restart";
            Command restartCommand = factory.Create(restartCommandName, GameEngine.Instance);
            string expectedMessage = "Welcome to “Bulls and Cows” game.\n\nPlease try to guess my secret 4-digit number.\nUse:\n'top' to view the top scoreboard\n'restart' to start a new game\n'help' to cheat\n'exit' to quit the game.";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                restartCommand.Execute(GameEngine.Instance.InputOutput);
                Assert.AreEqual<string>(expectedMessage, sw.ToString());

                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
        }
         * 
         * */
    }
}