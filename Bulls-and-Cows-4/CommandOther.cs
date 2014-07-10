namespace BullsAndCowsGame
{
    class CommandOther: Command
    {
        public CommandOther(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute()
        {
            //TODO
            engine.Action();
        }
    }
}
