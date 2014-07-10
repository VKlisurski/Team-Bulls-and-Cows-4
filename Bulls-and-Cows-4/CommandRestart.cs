namespace BullsAndCowsGame
{
    class CommandRestart : Command
    {
        public CommandRestart(GameEngine engine) :
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
