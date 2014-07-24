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

        public void Write(string format, object arg0)
        {
            Console.Write(format, arg0);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string message, object arg0)
        {
            Console.WriteLine(message, arg0);
        }

        public void WriteLine(string message, object arg0, object arg1)
        {
            Console.WriteLine(message, arg0, arg1);
        }

        public void WriteLine(string message, object arg0, object arg1, object arg2)
        {
            Console.WriteLine(message, arg0, arg1, arg2);
        }

        public void WriteLine(string message, object arg0, object arg1, object arg2, object arg3)
        {
            Console.WriteLine(message, arg0, arg1, arg2, arg3);
        }

        public void WriteLine(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}