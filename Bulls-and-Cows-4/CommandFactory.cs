namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class CommandCreator : FactoryMethod
    {
        public override Command Create(string commandName, GameEngine engine)
        {
            var parsedCommandName = commandName.ToLower();

            switch (parsedCommandName)
            {
                case "top": return new CommandTop(engine); break;
                case "restart": return new CommandRestart(engine); break;
                case "help": return new CommandHelp(engine); break;
                case "exit": return new CommandExit(engine); break;
                default: return new CommandOther(engine); break;
            }
        }
    }
}
