namespace BullsAndCowsGame
{
    using System;

    public class CommandOther : Command
    {
        public CommandOther(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            inputOutput.WriteLine(Message.InvalidCommand());
        }
    }
}
