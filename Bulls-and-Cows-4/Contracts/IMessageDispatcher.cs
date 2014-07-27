namespace BullsAndCowsGame.Contracts
{
    /// <summary>
    /// Implementations of this interface are used to produce messages for the player.
    /// </summary>
    public interface IMessageDispatcher
    {
        /// <summary>
        /// Returns a formatted string displaying information about the players in the given leaderboard.
        /// </summary>
        /// <param name="leaderBoard">The leaderboard to be displayed.</param>
        /// <returns>The socreboard information formatted as a string.</returns>
        string GetScoreBoard(LeaderBoard<Player> leaderBoard);

        /// <summary>
        /// This should be invoked when the player guesses the right number. It returns a congratulations message containing information about how many attempts were made.
        /// </summary>
        /// <param name="helper">The helper used during the game.</param>
        /// <param name="attempts">How many attempts did the player make to guess the number.</param>
        /// <returns>The congratulations message.</returns>
        string GetCongatulationsMessage(Helper helper, int attempts);

        /// <summary>
        /// This is invoked when the player enters a wrong guess number. It returns a message with information about how many bulls and how many cows did the guess number have.
        /// </summary>
        /// <param name="bullsCount">How many bulls did the guess number have.</param>
        /// <param name="cowsCount">How many cows did the guess number have.</param>
        /// <returns>A message holding information if how many bulls and cows were in the guess number.</returns>
        string GetWrongNumberMessage(int bullsCount, int cowsCount);

        /// <summary>
        /// A welcome message to be displayed to the player when he starts a new game.
        /// </summary>
        string GetWelcomeMessage();

        /// <summary>
        /// Returns a goodbye message to be displayed to the player.
        /// </summary>
        /// <returns>The goodbye message.</returns>
        string GetGoodbyeMessage();

        /// <summary>
        /// Returns a message notifying the player he entered an invalid command.
        /// </summary>
        /// <returns>The invalid command message.</returns>
        string GetInvalidCommandMessage();

        /// <summary>
        /// Returns a message notifying the player he is not allowed to cheat anymore.
        /// </summary>
        /// <returns>The "not allowed to cheat anymore" message.</returns>
        string GetNoCheatersMessage();

        /// <summary>
        /// Returns a message asking the player to enter his name.
        /// </summary>
        /// <returns>The "enter name" message.</returns>
        string GetEnterNameMessage();

        /// <summary>
        /// Returns a message asking the player to enter command.
        /// </summary>
        /// <returns>The "enter command" message.</returns>
        string GetEnterCommandMessage();
    }
}