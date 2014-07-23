namespace BullsAndCowsGame
{
    using Contracts;

    /// <summary>
    /// 
    /// </summary>
    public abstract class Command
    {
        public Command(IGameEngine engine)
        {
            this.Engine = engine;
        }

        protected IGameEngine Engine { get; set; }

        public abstract void Execute(InputOutput inputOutput);
    }
}