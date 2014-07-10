namespace BullsAndCowsGame
{
    internal class CommandCreator : FactoryMethod
    {
        public override Command Create(string commandName, GameEngine engine)
        {
            var parsedCommandName = commandName.ToLower();

            switch (parsedCommandName)
            {
                case "top": return new CommandTop(engine);
                case "restart": return new CommandRestart(engine);
                case "help": return new CommandHelp(engine);
                case "exit": return new CommandExit(engine);
                default: return new CommandOther(engine);
            }
        }
    }
}
