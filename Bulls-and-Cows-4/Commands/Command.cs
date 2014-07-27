namespace BullsAndCowsGame
{
    using Contracts;

    /// <summary>
    /// This is a base class inherited by all command classes in the game.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Initializes a new instance of a class inheriting the BullsAndCowsGame.Command class.
        /// </summary>
        /// <param name="engine">The engine on which the current command would be executed on.</param>
        protected Command(IGameEngine engine)
        {
            this.Engine = engine;
        }

        /// <summary>
        /// Gets or sets the engine to be used by the current command.
        /// </summary>
        protected IGameEngine Engine { get; set; }

        /// <summary>
        /// Executes the current command.
        /// </summary>
        /// <param name="inputOutput">The input and output to be used by the current command.</param>
        public abstract void Execute(InputOutput inputOutput);
    }
}