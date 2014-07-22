namespace BullsAndCowsGame
{
    using System;
    using System.Text;
    using Contracts;

    public class MessageDispatcher : IMessageDispatcher
    {
        private const string GoodByeMessage = "Good bye!";
        private const string InvalidCommandMessage = "Invalid guess or command!";
        private const string NoCheatersMessage = "Cheaters are not allowed to enter the top scoreboard.";
        private const string EnterNameMessage = "Please enter your name for the top scoreboard: ";
        private const string EnterCommandMessage = "Enter your guess or command: ";
        private const string WelcomeMessage = "Welcome to “Bulls and Cows” game.\nPlease try to guess my secret 4-digit number.\nUse:\n'top' to view the top scoreboard\n'restart' to start a new game\n'help' to cheat\n'exit' to quit the game.";

        public string GetGoodbyeMessage()
        {
            return GoodByeMessage;
        }

        public string GetInvalidCommandMessage()
        {
            return InvalidCommandMessage;
        }

        public string GetNoCheatersMessage()
        {
            return NoCheatersMessage;
        }

        public string GetEnterNameMessage()
        {
            return EnterNameMessage;
        }

        public string GetEnterCommandMessage()
        {
            return EnterCommandMessage;
        }

        public string GetWelcomeMessage()
        {
            return WelcomeMessage;
        }

        public string GetWrongNumberMessage(int bullsCount, int cowsCount)
        {
            return String.Format("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
        }

        public string GetScoreBoard(LeaderBoard<Player> leaderBoard)
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

        public string GetCongatulationsMessage(Helper helper, int attempts)
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
    }
}
