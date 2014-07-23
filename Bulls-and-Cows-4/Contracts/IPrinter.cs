namespace BullsAndCowsGame.Contracts
{
    public interface IPrinter
    {
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
