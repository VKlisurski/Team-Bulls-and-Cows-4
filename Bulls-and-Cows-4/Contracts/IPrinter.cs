namespace BullsAndCowsGame.Contracts
{
    /// <summary>
    /// Implementations of this are used to output messages to the player.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Writes the specified string value to the output defined by the implementation of this interface.
        /// </summary>
        /// <param name="message">The value to write.</param>
        void Write(string message);

        void Write(string format, object arg0);

        void WriteLine();

        void WriteLine(string message);

        void WriteLine(string message, object arg0);

        void WriteLine(string message, object arg0, object arg1);

        void WriteLine(string message, object arg0, object arg1, object arg2);

        void WriteLine(string message, object arg0, object arg1, object arg2, object arg3);

        void WriteLine(string message, params object[] args);
    }
}