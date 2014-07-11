namespace BullsAndCowsGame
{
    internal class CommandOther : Command
    {
        public CommandOther(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute()
        {
            Engine.PrintWrongCommandMessage();
        }
    }
}
