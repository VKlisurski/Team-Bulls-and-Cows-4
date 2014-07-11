namespace BullsAndCowsGame
{
    internal abstract class Command
    {
        public Command(GameEngine engine)
        {
            this.Engine = engine;
        }

        protected GameEngine Engine { get; set; }

        public abstract void Execute();
    }
}
