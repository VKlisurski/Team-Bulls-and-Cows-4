namespace BullsAndCowsGame
{
    using Contracts;

    /// <summary>
    /// A command to be executed when it's time for the player to leave the game.
    /// </summary>
    public class CommandExit : Command
    {
        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.CommandExit class.
        /// </summary>
        /// <param name="engine">The engine on which the current command would be executed on.</param>
        public CommandExit(IGameEngine engine) :
            base(engine)
        {
        }

        /// <summary>
        /// Executes the current command.
        /// </summary>
        /// <param name="inputOutput">The input and output to be used by the current command.</param>
        public override void Execute(InputOutput inputOutput)
        {
            this.Engine.Exit();
        }
    }
}