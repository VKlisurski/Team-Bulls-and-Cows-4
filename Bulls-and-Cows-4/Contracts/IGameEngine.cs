namespace BullsAndCowsGame.Contracts
{
    // Bridge Pattern
    public interface IGameEngine
    {
        void Start();

        void Exit();

        void Restart();

        string GetHelp();

        LeaderBoard<Player> GetScoreBoard();

        IMessageDispatcher MessageDispatcher { get; }
    }
}
