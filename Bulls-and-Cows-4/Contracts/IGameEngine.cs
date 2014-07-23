namespace BullsAndCowsGame.Contracts
{
    // Bridge Pattern
    public interface IGameEngine
    {
        LeaderBoard<Player> LeaderBoard { get; }

        IMessageDispatcher MessageDispatcher { get; }

        void Start();

        void Exit();

        void Restart();

        string GetHelp();
    }
}