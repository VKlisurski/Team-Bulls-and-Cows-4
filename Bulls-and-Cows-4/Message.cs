using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    internal static class Message
    {
        private const string GoodbyeMessage = "Good bye!";
        private const string InvalidMessage = "Invalid guess or command!";
        private const string NoCheatersMessage = "Cheaters are not allowed to enter the top scoreboard.";
        private const string EnterNameMessage = "Please enter your name for the top scoreboard: ";
        private const string EnterCommandMessage = "Enter your guess or command: ";

        internal static string Goodbye()
        {
            return GoodbyeMessage;
        }

        internal static string InvalidCommand()
        {
            return InvalidMessage;
        }

        internal static string NoCheaters()
        {
            return NoCheatersMessage;
        }

        internal static string EnterName()
        {
            return EnterNameMessage;
        }

        internal static string EnterCommand()
        {
            return EnterCommandMessage;
        }

        internal static string GetScoreBoard(LeaderBoard<Player> leaderBoard)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (leaderBoard.Count == 0)
            {
                stringBuilder.Append("Top scoreboard is empty.");
            }
            else
            {
                stringBuilder.Append("Scoreboard:");
                int i = 1;
                string currentAttemptsMessage;

                foreach (Player p in leaderBoard)
                {
                    currentAttemptsMessage = String.Format("{0}. {1} --> {2} guess" + ((p.Attempts == 1) ? string.Empty : "es"), i++, p.Name, p.Attempts);
                    stringBuilder.Append(currentAttemptsMessage);
                }
            }

            return stringBuilder.ToString();
        }

        internal static string Congratulate(Helper helper, int attempts)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(string.Format("Congratulations! You guessed the secret number in {0} attempts", attempts));
            if (helper.Cheats == 0)
            {
                stringBuilder.Append(".");
            }
            else
            {
                stringBuilder.Append(String.Format(" and {0} cheats.", helper.Cheats));
            }

            return stringBuilder.ToString();
        }

        internal static string WrongNumber(int bullsCount, int cowsCount)
        {
            return String.Format("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
        }

        internal static string WelcomeMessage()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Welcome to “Bulls and Cows” game.");
            sb.AppendLine("Please try to guess my secret 4-digit number.");
            sb.AppendLine("Use 'top' to view the top scoreboard, 'restart'");
            sb.AppendLine("to start a new game and 'help' to cheat and 'exit' to quit the game.");

            return sb.ToString();
        }
    }
}
