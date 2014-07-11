namespace BullsAndCowsGame
{
    internal class CommandTop : Command
    {
        public CommandTop(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute()
        {
            Engine.PrintScoreboard();
        }
    }
}
