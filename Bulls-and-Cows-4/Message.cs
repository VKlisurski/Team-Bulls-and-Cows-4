using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCowsGame
{
    public static class Message
    {
        private const string GOODBYE_MESSAGE = "Good bye!";
        private const string INVALID_COMMAND_MESSAGE = "Invalid guess or command!";
        private const string NO_CHEATERS_MESSAGE = "Cheaters are not allowed to enter the top scoreboard.";
        private const string ENTER_NAME_MESSAGE = "Please enter your name for the top scoreboard: ";
        private const string ENTER_COMMAND_MESSAGE = "Enter your guess or command: ";

        public static string Goodbye()
        {
            return GOODBYE_MESSAGE;
        }

        public static string InvalidCommand()
        {
            return INVALID_COMMAND_MESSAGE;
        }

        public static string NoCheaters()
        {
            return NO_CHEATERS_MESSAGE;
        }

        public static string EnterName()
        {
            return ENTER_NAME_MESSAGE;
        }

        public static string EnterCommand()
        {
            return ENTER_COMMAND_MESSAGE;
        }

        public static string GetScoreBoard(LeaderBoard<Player> leaderBoard)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (leaderBoard.Count == 0)
            {
                stringBuilder.Append("Top scoreboard is empty.");
            }
            else
            {
                stringBuilder.Append("Scoreboard:\n");
                int i = 1;
                string currentAttemptsMessage;

                foreach (Player player in leaderBoard)
                {
                    currentAttemptsMessage = String.Format("{0}. {1} --> {2} guess" + ((player.Attempts == 1) ? string.Empty : "es") + "\n", i++, player.Name, player.Attempts);
                    stringBuilder.Append(currentAttemptsMessage);
                }
            }

            return stringBuilder.ToString();
        }

        public static string Congratulate(Helper helper, int attempts)
        {
            if (attempts <= 0)
            {
                throw new ArgumentException("The number of attemps to win the game cannot be zero or negative integer");
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(string.Format("Congratulations!\nYou guessed the secret number in {0} attempt" + (attempts > 1 ? "s" : ""), attempts));
            
            if (helper.Cheats == 0)
            {
                stringBuilder.Append(".");
            }
            else
            {
                stringBuilder.Append(String.Format(" and {0} cheat" + (helper.Cheats > 1 ? "s." : "."), helper.Cheats));
            }

            return stringBuilder.ToString();
        }

        public static string WrongNumber(int bullsCount, int cowsCount)
        {
            return String.Format("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
        }

        public static string WelcomeMessage()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.AppendLine("Welcome to “Bulls and Cows” game.");
            welcomeMessage.AppendLine();
            welcomeMessage.AppendLine("Please try to guess my secret 4-digit number.");
            welcomeMessage.AppendLine("Use:");
            welcomeMessage.AppendLine("'top' to view the top scoreboard");
            welcomeMessage.AppendLine("'restart' to start a new game");
            welcomeMessage.AppendLine("'help' to cheat"); 
            welcomeMessage.AppendLine("'exit' to quit the game.");

            return welcomeMessage.ToString();
        }
    }
}
