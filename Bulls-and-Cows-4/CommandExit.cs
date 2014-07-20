namespace BullsAndCowsGame
{
    using Contracts;

    public class CommandExit : Command
    {
        public CommandExit(IGameEngine engine) :
            base(engine)
        {
        }

        public override void Execute(InputOutput inputOutput)
        {
            Engine.Exit();
        }
    }
}
