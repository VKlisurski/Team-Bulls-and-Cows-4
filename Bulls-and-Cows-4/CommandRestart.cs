namespace BullsAndCowsGame
{
    using Contracts;

    public class CommandRestart : Command
    {
        public CommandRestart(IGameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            Engine.Restart();
        }
    }
}
