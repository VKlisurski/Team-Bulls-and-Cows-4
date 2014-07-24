namespace BullsAndCowsGame.Contracts
{
    /// <summary>
    /// Different types of calculation strategies implement this interface.
    /// </summary>
    public interface ICalculateBullsAndCowsStrategy
    {
        /// <summary>
        /// Executes the current strategy.
        /// </summary>
        /// <param name="playerInput">The guess number entered by the player.</param>
        /// <param name="generatedNumber">The original number that needs to be found out.</param>
        /// <returns>An object containing information about how many bulls and how many cows did the current guess number have.</returns>
        GuessResult ExecuteStrategy(string playerInput, string generatedNumber);
    }
}