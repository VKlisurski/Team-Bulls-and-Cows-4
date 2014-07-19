using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCowsGame;

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
    }
}
