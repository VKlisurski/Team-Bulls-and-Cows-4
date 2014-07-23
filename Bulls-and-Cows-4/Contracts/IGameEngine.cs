namespace BullsAndCowsGame.Contracts
{
    // Bridge Pattern
    public interface IGameEngine
    {
        void Start();

        void Exit();

        void Restart();

        string GetHelp();

        LeaderBoard<Player> LeaderBoard { get; }

        IMessageDispatcher MessageDispatcher { get; }
    }
}