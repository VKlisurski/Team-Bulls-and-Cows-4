namespace BullsAndCowsGame
{
    using System;
    using Contracts;

    /// <summary>
    /// This is used to read input by a player from the console.
    /// </summary>
    public class ConsoleReader : IReader
    {
        /// <summary>
        /// Reads a line written by the player to the console.
        /// </summary>
        /// <returns>Reads the next line of characters from the standard input stream.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}