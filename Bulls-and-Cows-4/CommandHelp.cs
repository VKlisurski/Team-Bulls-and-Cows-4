using System;
namespace BullsAndCowsGame
{
    internal class CommandHelp : Command
    {
        public CommandHelp(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute()
        {
            Console.WriteLine(Engine.GetHelp());
        }
    }
}
