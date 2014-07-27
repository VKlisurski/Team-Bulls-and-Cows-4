namespace BullsAndCowsGame
{
    using System;
    using Contracts;

    /// <summary>
    /// This is used by the player to write on the standard output stream.
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="message">The value to write.</param>
        public void Write(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Writes a new line to the standard output stream.
        /// </summary>
        public void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the specified string value to the standard output stream, followed by a new line.
        /// </summary>
        /// <param name="message">The value to write.</param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }        
    }
}