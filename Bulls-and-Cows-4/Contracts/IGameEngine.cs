namespace BullsAndCowsGame.Contracts
{
    /// <summary>
    /// Implementations of this interface are used to run the core Bulls and Cows game logic.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Gets an instance holding information of the top scoring players.
        /// </summary>
        LeaderBoard<Player> LeaderBoard { get; }

        /// <summary>
        /// Gets an instance used to provide messages to the player.
        /// </summary>
        IMessageDispatcher MessageDispatcher { get; }

        /// <summary>
        /// Used to start the game.
        /// </summary>
        void Start();

        /// <summary>
        /// Used to exit the game.
        /// </summary>
        void Exit();

        /// <summary>
        /// Used to restart the game.
        /// </summary>
        void Restart();

        /// <summary>
        /// Used to get help for the player, who wants to cheat.
        /// </summary>
        /// <returns>A string representing the original number, with some of it's digits hidden.</returns>
        string GetHelp();
    }
}