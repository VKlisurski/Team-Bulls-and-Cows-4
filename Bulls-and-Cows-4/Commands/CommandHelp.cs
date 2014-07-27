namespace BullsAndCowsGame
{
    using System;
    using Contracts;

    /// <summary>
    /// A command to be executed when the player asks for help.
    /// </summary>
    public class CommandHelp : Command
    {
        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.CommandHelp class.
        /// </summary>
        /// <param name="engine">The engine on which the current command would be executed on.</param>
        public CommandHelp(IGameEngine engine) :
            base(engine)
        {
        }

        /// <summary>
        /// Executes the current command.
        /// </summary>
        /// <param name="inputOutput">The input and output to be used by the current command.</param>
        public override void Execute(InputOutput inputOutput)
        {
            inputOutput.WriteLine(this.Engine.GetHelp());
        }
    }
}