namespace BullsAndCowsGame.Contracts
{
    /// <summary>
    /// Implementations of this interface are used to read input from the player.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads a single line of characters entered by the player.
        /// </summary>
        /// <returns>Reads a line of characters.</returns>
        string ReadLine();
    }
}