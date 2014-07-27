namespace BullsAndCowsGame
{
    using Contracts;

    /// <summary>
    /// A command to be executed when the player wants to restart the game.
    /// </summary>
    public class CommandRestart : Command
    {
        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.CommandRestart class.
        /// </summary>
        /// <param name="engine">The engine on which the current command would be executed.</param>
        public CommandRestart(IGameEngine engine) :
            base(engine)
        {
        }

        /// <summary>
        /// Executes the current command.
        /// </summary>
        /// <param name="inputOutput">The input and output to be used by the current command.</param>
        public override void Execute(InputOutput inputOutput)
        {
            this.Engine.Restart();
        }
    }
}