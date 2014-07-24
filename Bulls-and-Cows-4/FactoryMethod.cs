namespace BullsAndCowsGame
{
    /// <summary>
    /// Implementation of the Factory Method pattern used to instantiate commands.
    /// </summary>
    public abstract class FactoryMethod
    {
        /// <summary>
        /// Creates a command by given name and engine.
        /// </summary>
        /// <param name="commandName">Name of the command to be created.</param>
        /// <param name="engine">Instance of the engine on which the command will be executed.</param>
        /// <returns></returns>
        public abstract Command Create(string commandName, GameEngine engine);
    }
}