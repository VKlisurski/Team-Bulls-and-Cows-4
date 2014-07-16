namespace BullsAndCowsGame
{
    internal class CommandRestart : Command
    {
        public CommandRestart(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            Engine.Restart();
        }
    }
}
