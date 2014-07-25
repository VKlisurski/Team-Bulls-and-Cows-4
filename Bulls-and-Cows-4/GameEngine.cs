namespace BullsAndCowsGame
{
    using System;
    using Contracts;

    /// <summary>
    /// The main class running the core Bulls and Cows game logic.
    /// </summary>
    public class GameEngine : IGameEngine
    {
        /// <summary>
        /// The default length a Bulls and Cows number should have.
        /// </summary>
        public const int DefaultNumberLength = 4;

        /// <summary>
        /// This holds the single instance our Bulls and Cows game can have.
        /// </summary>
        private static GameEngine game;

        /// <summary>
        /// This is a factory method instance, responsible for the creation of commands.
        /// </summary>
        private readonly FactoryMethod commandCreator = new CommandCreator();

        /// <summary>
        /// All information about the leaderboard and the players inside it is stored here.
        /// </summary>
        private readonly LeaderBoard<Player> leaderBoard = new LeaderBoard<Player>();

        /// <summary>
        /// All messages to be displayed to the player are provided here.
        /// </summary>
        private IMessageDispatcher messageDispatcher = new MessageDispatcher();

        /// <summary>
        /// All game numbers are provided from here. Also validations 
        /// </summary>
        private GameNumberProvider numberProvider = new GameNumberProvider();

        /// <summary>
        /// This holds the amount of attempts a player made to guess the number in his current game.
        /// </summary>
        private int attempts;

        /// <summary>
        /// This is the original number to be guessed, generated for the current game.
        /// </summary>
        private string generatedNumber;

        /// <summary>
        /// This shows if the game is currently running or not.
        /// </summary>
        private bool gameOn;

        /// <summary>
        /// Used to provide help to the player, when he opts to cheat.
        /// </summary>
        private Helper helper;

        /// <summary>
        /// The type of calculation strategy for a game is being stored here.
        /// </summary>
        private ICalculateBullsAndCowsStrategy calculateBullsAndCowStrategy;

        /// <summary>
        /// Used to communicate to and from the player.
        /// </summary>
        private InputOutput inputOutput;

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.GameEngine class.
        /// </summary>
        /// <param name="helper">The helper class to be used by the engine.</param>
        /// <param name="calculateBullsAndCowsStrategy">A calculation strategy to be used in the game.</param>
        /// <param name="inputOutput">The inputout class to be used for communication with the player.</param>
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

        /// <summary>
        /// A singleton implementation holding the only possible instance of the BullsAndCowsGame.GameEngine class.
        /// </summary>
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

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of attemps in a game cannot be a negative integer.");
                }

                this.attempts = value;
            }
        }

        /// <summary>
        /// Gets or sets the helper class to be used by the game engine.
        /// </summary>
        public Helper Helper
        {
            get
            {
                return this.helper;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The Helper value cannot be null.");
                }

                this.helper = value;
            }
        }

        /// <summary>
        /// Gets or sets a flag, used by the game engine to determine if the game is running.
        /// </summary>
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

        /// <summary>
        /// Gets or sets an instance used to provide messages to the player.
        /// </summary>
        public IMessageDispatcher MessageDispatcher
        {
            get
            {
                return this.messageDispatcher;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The MessageDispatcher value cannot be null.");
                }

                this.messageDispatcher = value;
            }
        }

        /// <summary>
        /// Gets or sets an instance used to provide a random number for the player to guess and also to determine if the guess number entered by the player is valid.
        /// </summary>
        public GameNumberProvider NumberProvider
        {
            get
            {
                return this.numberProvider;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The NumberProvider value cannot be null.");
                }

                this.numberProvider = value;
            }
        }

        /// <summary>
        /// Gets an instance holding information of the top scoring players.
        /// </summary>
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
                    playerCommand.Execute(this.inputOutput);
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
        
        /// <summary>
        /// If no cheats were used gathers player information for the score board and restarts the game. If any cheats were used, just restarts the game.
        /// </summary>
        private void FinishGame()
        {
            if (this.Helper.Cheats == 0)
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