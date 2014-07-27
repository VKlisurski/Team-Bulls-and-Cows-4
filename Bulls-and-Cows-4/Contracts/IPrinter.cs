namespace BullsAndCowsGame.Contracts
{
    /// <summary>
    /// Implementations of this interface are used to output messages to the player.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Writes the specified string value to the output defined by the implementation of this interface.
        /// </summary>
        /// <param name="message">The value to write.</param>
        void Write(string message);

        /// <summary>
        /// Writes a new line to the standard output stream.
        /// </summary>
        void WriteLine();

        /// <summary>
        /// Writes the specified string value to the standard output stream, followed by a new line.
        /// </summary>
        /// <param name="message">The value to write.</param>
        void WriteLine(string message);
    }
}