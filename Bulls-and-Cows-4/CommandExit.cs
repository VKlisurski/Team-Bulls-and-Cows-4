namespace BullsAndCowsGame
{
    public class CommandExit : Command
    {
        public CommandExit(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            Engine.Exit();
        }
    }
}
