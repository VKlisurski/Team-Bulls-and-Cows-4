namespace BullsAndCowsGame
{
    using Contracts;

    //Façade
    public class InputOutput
    {
        private IReader reader;
        private IPrinter printer;

        public InputOutput() : this(new ConsoleReader(), new ConsolePrinter())
        { 
        }

        public InputOutput(IReader reader, IPrinter printer)
        {
            this.reader = reader;
            this.printer = printer;
        }

        public void WriteLine()
        {
            this.printer.WriteLine();
        }
        public void WriteLine(string message)
        {
            this.printer.WriteLine(message);
        }

        public void WriteLine(string message, object arg0)
        {
            this.printer.WriteLine(message, arg0);
        }

        public void WriteLine(string message, object arg0, object arg1)
        {
            this.printer.WriteLine(message, arg0, arg1);
        }

        public void WriteLine(string message, object arg0, object arg1, object arg2)
        {
            this.printer.WriteLine(message, arg0, arg1, arg2);
        }

        public void WriteLine(string message, object arg0, object arg1, object arg2, object arg3)
        {
            this.printer.WriteLine(message, arg0, arg1, arg2, arg3);
        }

        public void WriteLine(string message, params object[] args)
        {
            this.printer.WriteLine(message, args);
        }

        public void Write(string message)
        {
            this.printer.Write(message);
        }

        public void Write(string message, object arg0)
        {
            this.printer.Write(message, arg0);
        }

        public string ReadLine()
        {
            return this.reader.ReadLine();
        }
    }
}
