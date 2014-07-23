namespace BullsAndCowsGame
{
    using System;
    using Contracts;

    /// <summary>
    /// The main class running the core Bulls and Cows game logic.
    /// </summary>
    public class GameEngine : IGameEngine
    {
        public const int DefaultNumberLength = 4;

        private static GameEngine game;
        private readonly FactoryMethod commandCreator = new CommandCreator();
        private int attempts;
        private string generatedNumber;
        private readonly LeaderBoard<Player> leaderBoard = new LeaderBoard<Player>();
        private bool gameOn;
        private Helper helper;
        private ICalculateBullsAndCowsStrategy calculateBullsAndCowStrategy;
        private InputOutput inputOutput;
        private IMessageDispatcher messageDispatcher = new MessageDispatcher();
        private GameNumberProvider numberProvider = new GameNumberProvider();

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.GameEngine class.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="calculateBullsAndCowsStrategy">A calculation strategy to be used in the game.</param>
        /// <param name="inputOutput"></param>
        private GameEngine(Helper helper, ICalculateBullsAndCowsStrategy calculateBullsAndCowsStrategy, InputOutput inputOutput)
        {
            this.Attempts = 0;
            this.Helper = helper;
            this.generatedNumber = this.numberProvider.Generate(GameEngine.DefaultNumberLength);
            this.GameOn = true;
            this.calculateBullsAndCowStrategy = calculateBullsAndCowsStrategy;
            this.inputOutput = inputOutput;
        }

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.GameEngine class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the amount of guess attemptes the player made in a game.
        /// </summary>
        public int Attempts
        {
            get
            {
                return this.attempts;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of attemps in a game cannot be a negative integer.");
                }

                this.attempts = value;
            }
        }

        public Helper Helper
        {
            get
            {
                return this.helper;
            }
            set
            {
                this.helper = value;
            }
        }

        public bool GameOn
        {
            get
            {
                return this.gameOn;
            }
            set
            {
                this.gameOn = value;
            }
        }

        public IMessageDispatcher MessageDispatcher
        {
            get
            {
                return this.messageDispatcher;
            }
            set
            {
                this.messageDispatcher = value;
            }
        }

        public GameNumberProvider NumberProvider
        {
            get
            {
                return this.numberProvider;
            }
            set
            {
                this.numberProvider = value;
            }
        }

        public LeaderBoard<Player> LeaderBoard
        {
            get
            {
                return this.leaderBoard;
            }
        }

        /// <summary>
        /// Starts the game and displays a welcome message.
        /// </summary>
        public void Start()
        {
            this.inputOutput.WriteLine(this.MessageDispatcher.GetWelcomeMessage());

            while (this.gameOn)
            {
                this.inputOutput.Write(this.MessageDispatcher.GetEnterCommandMessage());
                string playerInput = this.inputOutput.ReadLine();

                if (this.numberProvider.IsValidNumber(playerInput, GameEngine.DefaultNumberLength))
                {
                    this.Attempts++;

                    GuessResult guessResult = this.calculateBullsAndCowStrategy.ExecuteStrategy(playerInput, this.generatedNumber);

                    if (guessResult.Bulls == GameEngine.DefaultNumberLength)
                    {
                        this.inputOutput.WriteLine(this.MessageDispatcher.GetCongatulationsMessage(this.Helper, this.Attempts));
                        this.FinishGame();
                    }
                    else
                    {
                        this.inputOutput.WriteLine(this.MessageDispatcher.GetWrongNumberMessage(guessResult.Bulls, guessResult.Cows));
                    }
                }
                else
                {
                    Command playerCommand = this.commandCreator.Create(playerInput, GameEngine.Instance);
                    playerCommand.Execute(inputOutput);
                }
            }            
        }

        /// <summary>
        /// Exits the game. A goodbye message is displayed.
        /// </summary>
        public void Exit()
        {
            this.GameOn = false;
            this.inputOutput.WriteLine(this.MessageDispatcher.GetGoodbyeMessage());
        }

        /// <summary>
        /// Restarts the game.
        /// </summary>
        public void Restart()
        {
            this.Attempts = 0;
            this.Helper.Cheats = 0;
            this.generatedNumber = this.numberProvider.Generate(DefaultNumberLength);
            this.Start();
        }

        /// <summary>
        /// Provides help to the player when he uses a cheat.
        /// </summary>
        /// <returns>A string representing the original number, with some of it's digits hidden.</returns>
        public string GetHelp()
        {
            return this.Helper.GetHelp(this.generatedNumber);
        }
        
        private void FinishGame()
        {
            if (this.helper.Cheats == 0)
            {
                this.inputOutput.Write(this.MessageDispatcher.GetEnterNameMessage());
                string playerName = this.inputOutput.ReadLine();
                this.AddPlayerToScoreboard(playerName);
                this.inputOutput.WriteLine(this.MessageDispatcher.GetScoreBoard(this.leaderBoard));
            }
            else
            {
                this.inputOutput.WriteLine(this.MessageDispatcher.GetNoCheatersMessage());
            }
            
            this.Restart();
        }

        /// <summary>
        /// Adds a player to the scoreboard.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        private void AddPlayerToScoreboard(string playerName)
        {
            Player player = new Player(playerName, this.Attempts);
            this.LeaderBoard.Add(player);
        }
    }
}