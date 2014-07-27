namespace BullsAndCowsGame
{
    using Contracts;

    /// <summary>
    /// A facade class used for reading data from the player and releasing data to the player.
    /// </summary>
    public class InputOutput
    {
        /// <summary>
        /// The reader to be used to get commands from the player.
        /// </summary>
        private IReader reader;

        /// <summary>
        /// The printer to be used to print commands to the player.
        /// </summary>
        private IPrinter printer;

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.InputOutput class.
        /// </summary>
        public InputOutput() : this(new ConsoleReader(), new ConsolePrinter())
        { 
        }

        /// <summary>
        /// Returns a new instance of the BullsAndCowsGame.InputOutput class.
        /// </summary>
        /// <param name="reader">The reader to be used for input.</param>
        /// <param name="printer">The printer to be used for output.</param>
        public InputOutput(IReader reader, IPrinter printer)
        {
            this.reader = reader;
            this.printer = printer;
        }

        /// <summary>
        /// Writes a new line on the output/
        /// </summary>
        /// <param name="message">Message to be written.</param>
        public void Write(string message)
        {
            this.printer.Write(message);
        }

        /// <summary>
        /// Writes a new line on the output.
        /// </summary>
        public void WriteLine()
        {
            this.printer.WriteLine();
        }

        /// <summary>
        /// Writes a new line on the output with new line attached at the end.
        /// </summary>
        /// <param name="message">Message to be written.</param>
        public void WriteLine(string message)
        {
            this.printer.WriteLine(message);
        }

        /// <summary>
        /// Reads a line from the input.
        /// </summary>
        /// <returns>Returns the read line.</returns>
        public string ReadLine()
        {
            return this.reader.ReadLine();
        }
    }
}