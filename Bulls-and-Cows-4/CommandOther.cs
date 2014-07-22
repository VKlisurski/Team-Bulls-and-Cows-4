namespace BullsAndCowsGame
{
    using System;

    using Contracts;

    public class CommandOther : Command
    {
        public CommandOther(IGameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            inputOutput.WriteLine(this.Engine.MessageDispatcher.GetInvalidCommandMessage());
        }
    }
}
