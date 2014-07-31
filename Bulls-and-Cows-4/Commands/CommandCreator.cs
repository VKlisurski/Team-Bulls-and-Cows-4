namespace BullsAndCowsGame
{
    /// <summary>
    /// A factory class resposible for the creation of commands.
    /// </summary>
    public class CommandCreator : CommandFactoryMethod
    {
        private const string TopCommand = "top";
        private const string RestartCommand = "restart";
        private const string HelpCommand = "help";
        private const string ExitCommand = "exit";

        /// <summary>
        /// Creates a new game command, according to the provided command name.
        /// </summary>
        /// <param name="commandName">Represents the command name.</param>
        /// <param name="engine">The engine on which the command should be executed.</param>
        /// <returns>A command, to be executed on the given engine.</returns>
        public override Command Create(string commandName, GameEngine engine)
        {
            var parsedCommandName = commandName.ToLower();

            switch (parsedCommandName)
            {
                case TopCommand: return new CommandTop(engine);
                case RestartCommand: return new CommandRestart(engine);
                case HelpCommand: return new CommandHelp(engine);
                case ExitCommand: return new CommandExit(engine);
                default: return new CommandOther(engine);
            }
        }
    }
}