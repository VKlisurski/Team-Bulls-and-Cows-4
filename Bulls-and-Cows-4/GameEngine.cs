namespace BullsAndCowsGame
{
    using System;
    using System.Text;    

    public class GameEngine
    {
        public const int DefaultNumberLength = 4;
        private static GameEngine game;
        private readonly CommandCreator commandCreator = new CommandCreator();
        private int attempts;
        private readonly string generatedNumber;
        private readonly LeaderBoard<Player> leaderBoard = new LeaderBoard<Player>();
        private bool gameOn;
        private readonly Helper helper;
        private ICalculateBullsAndCowsStrategy calculateBullsAndCowStrategy;

        private GameEngine()
        {
            this.attempts = 0;
            this.helper = new Helper();
            this.generatedNumber = this.GenerateNumber();
            this.gameOn = true;
            this.calculateBullsAndCowStrategy = new NormalCalculateBullsAndCowsStrategy(this.generatedNumber);
        }

        public static GameEngine Instance
        {
            get
            {
                if (game == null)
                {
                    game = new GameEngine();
                }

                return game;
            }
        }

        public void Start()
        {
            this.PrintWelcomeMessage();

            while (this.gameOn)
            {
                Console.Write("Enter your guess or command: ");

                string playerInput = Console.ReadLine();

                if (this.IsValidNumber(playerInput))
                {
                    int bullsCount;
                    int cowsCount;
                    this.attempts++;

                    this.calculateBullsAndCowStrategy.ExecuteStrategy(playerInput, out bullsCount, out cowsCount);

                    if (bullsCount == DefaultNumberLength)
                    {
                        this.PrintCongratulateMessage();
                        this.FinishGame();
                    }
                    else
                    {
                        Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
                    }
                }
                else
                {
                    Command playerCommand = this.commandCreator.Create(playerInput, game);
                    playerCommand.Execute();
                }
            }

            Console.WriteLine("Good bye!");
        }

        internal void PrintWrongCommandMessage()
        {
            Console.WriteLine("Invalid guess or command!");
        }

        internal void Exit()
        {
            this.gameOn = false;
        }

        internal void Restart()
        {
            this.PrintWelcomeMessage();
            game = new GameEngine();
        }

        internal void PrintHelp()
        {
            this.helper.DisplayHelp(this.generatedNumber);
        }

        internal void PrintScoreboard()
        {
            if (this.leaderBoard.Count == 0)
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 1;
                foreach (Player p in this.leaderBoard)
                {
                    Console.WriteLine("{0}. {1} --> {2} guess" + ((p.Attempts == 1) ? string.Empty : "es"), i++, p.Name, p.Attempts);
                }
            }
        }

        private void FinishGame()
        {
            if (this.helper.Cheats == 0)
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string playerName = Console.ReadLine();
                this.AddPlayerToScoreboard(playerName);
                this.PrintScoreboard();
            }
            else
            {
                Console.WriteLine("Cheaters are not allowed to enter the top scoreboard.");
            }

            this.Restart();
        }

        private void AddPlayerToScoreboard(string playerName)
        {
            Player player = new Player(playerName, this.attempts);
            this.leaderBoard.Add(player);
        }

        private void PrintCongratulateMessage()
        {
            Console.Write("Congratulations! You guessed the secret number in {0} attempts", this.attempts);
            if (this.helper.Cheats == 0)
            {
                Console.WriteLine(".");
            }
            else
            {
                Console.WriteLine(" and {0} cheats.", this.helper.Cheats);
            }
        }

        //private void CalculateBullsAndCowsCount(string playerInput, string generatedNumber, out int bullsCount, out int cowsCount)
        //{
        //    bullsCount = 0;
        //    cowsCount = 0;
        //    StringBuilder playerNumber = new StringBuilder(playerInput);
        //    StringBuilder number = new StringBuilder(generatedNumber);
        //    for (int i = 0; i < playerNumber.Length; i++)
        //    {
        //        if (playerNumber[i] == number[i])
        //        {
        //            bullsCount++;
        //            playerNumber.Remove(i, 1);
        //            number.Remove(i, 1);
        //            i--;
        //        }
        //    }

        //    for (int i = 0; i < playerNumber.Length; i++)
        //    {
        //        for (int j = 0; j < number.Length; j++)
        //        {
        //            if (playerNumber[i] == number[j])
        //            {
        //                cowsCount++;
        //                playerNumber.Remove(i, 1);
        //                number.Remove(j, 1);
        //                j--;
        //                i--;
        //                break;
        //            }
        //        }
        //    }
        //}

        private bool IsValidNumber(string playerInput)
        {
            // Useless validation?
            if (playerInput == string.Empty || playerInput.Length != DefaultNumberLength)
            {
                return false;
            }

            // May be try parse the input and return false on error?
            for (int i = 0; i < playerInput.Length; i++)
            {
                char currentChar = playerInput[i];

                if (!char.IsDigit(currentChar))
                {
                    return false;
                }
            }

            return true;
        }

        private string GenerateNumber()
        {
            StringBuilder num = new StringBuilder(4);
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < DefaultNumberLength; i++)
            {
                int randomDigit = randomNumberGenerator.Next(9);

                num.Append(randomDigit);
            }

            return num.ToString();
        }

        private void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game.");
            Console.WriteLine("Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart'");
            Console.WriteLine("to start a new game and 'help' to cheat and 'exit' to quit the game.");
        }
    }
}
