namespace BullsAndCowsGame
{
    class CommandExit : Command
    {
        public CommandExit(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute()
        {
            engine.Exit();
        }
    }
}
