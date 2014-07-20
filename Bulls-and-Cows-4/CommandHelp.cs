namespace BullsAndCowsGame
{
    using System;

    using Contracts;

    public class CommandHelp : Command
    {
        public CommandHelp(IGameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            inputOutput.WriteLine(Engine.GetHelp());
        }
    }
}
