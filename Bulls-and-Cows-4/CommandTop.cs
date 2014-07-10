namespace BullsAndCowsGame
{
    class CommandTop : Command
    {
        public CommandTop(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute()
        {
            engine.PrintScoreboard();
        }
    }
}
