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
        private string generatedNumber;
        private readonly LeaderBoard<Player> leaderBoard = new LeaderBoard<Player>();
        private bool gameOn;
        private readonly Helper helper;
        private ICalculateBullsAndCowsStrategy calculateBullsAndCowStrategy;
        private InputOutput inputOutput;

        private GameEngine(Helper helper, ICalculateBullsAndCowsStrategy calculateBullsAndCowsStrategy, InputOutput inputOutput)
        {
            this.attempts = 0;
            this.helper = helper;
            this.generatedNumber = this.GenerateNumber();
            this.gameOn = true;
            this.calculateBullsAndCowStrategy = calculateBullsAndCowsStrategy;
            this.inputOutput = inputOutput;
        }

        private GameEngine()
            : this(new Helper(), new NormalCalculateBullsAndCowsStrategy(), new InputOutput())
        {
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
                this.inputOutput.Write("Enter your guess or command: ");

                string playerInput = this.inputOutput.ReadLine();

                if (this.IsValidNumber(playerInput))
                {
                    int bullsCount;
                    int cowsCount;
                    this.attempts++;

                    this.calculateBullsAndCowStrategy.ExecuteStrategy(playerInput, this.generatedNumber, out bullsCount, out cowsCount);

                    if (bullsCount == DefaultNumberLength)
                    {
                        this.PrintCongratulateMessage();
                        this.FinishGame();
                    }
                    else
                    {
                        this.inputOutput.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
                    }
                }
                else
                {
                    Command playerCommand = this.commandCreator.Create(playerInput, game);
                    playerCommand.Execute();
                }
            }

            this.inputOutput.WriteLine("Good bye!");
        }

        internal void PrintWrongCommandMessage()
        {
            this.inputOutput.WriteLine("Invalid guess or command!");
        }

        internal void Exit()
        {
            this.gameOn = false;
        }

        internal void Restart()
        {
            this.attempts = 0;
            this.helper.Cheats = 0;
            this.generatedNumber = GenerateNumber();
            this.Start();
        }

        internal void PrintHelp()
        {
            this.inputOutput.WriteLine(this.helper.GetHelp(this.generatedNumber));
        }

        internal void PrintScoreboard()
        {
            if (this.leaderBoard.Count == 0)
            {
                this.inputOutput.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                this.inputOutput.WriteLine("Scoreboard:");
                int i = 1;
                foreach (Player p in this.leaderBoard)
                {
                    this.inputOutput.WriteLine("{0}. {1} --> {2} guess" + ((p.Attempts == 1) ? string.Empty : "es"), i++, p.Name, p.Attempts);
                }
            }
        }

        private void FinishGame()
        {
            if (this.helper.Cheats == 0)
            {
                this.inputOutput.Write("Please enter your name for the top scoreboard: ");
                string playerName = this.inputOutput.ReadLine();
                this.AddPlayerToScoreboard(playerName);
                this.PrintScoreboard();
            }
            else
            {
                this.inputOutput.WriteLine("Cheaters are not allowed to enter the top scoreboard.");
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
            this.inputOutput.Write("Congratulations! You guessed the secret number in {0} attempts", this.attempts);
            if (this.helper.Cheats == 0)
            {
                this.inputOutput.WriteLine(".");
            }
            else
            {
                this.inputOutput.WriteLine(" and {0} cheats.", this.helper.Cheats);
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
            this.inputOutput.WriteLine("Welcome to “Bulls and Cows” game.");
            this.inputOutput.WriteLine("Please try to guess my secret 4-digit number.");
            this.inputOutput.WriteLine("Use 'top' to view the top scoreboard, 'restart'");
            this.inputOutput.WriteLine("to start a new game and 'help' to cheat and 'exit' to quit the game.");
        }
    }
}
