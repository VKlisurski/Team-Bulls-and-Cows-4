namespace BullsAndCowsGame
{
    using System;

    using Contracts;

    public class ConsolePrinter : IPrinter
    {

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
