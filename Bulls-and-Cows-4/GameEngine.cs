namespace BullsAndCowsGame
{
    using System;
    using Contracts;

    public class GameEngine : IGameEngine
    {
        public const int DefaultNumberLength = 4;

        private static GameEngine game;
        private readonly FactoryMethod commandCreator = new CommandCreator();
        private int attempts;
        private string generatedNumber;
        private readonly LeaderBoard<Player> leaderBoard = new LeaderBoard<Player>();
        private bool gameOn;
        private readonly Helper helper;
        private ICalculateBullsAndCowsStrategy calculateBullsAndCowStrategy;
        private InputOutput inputOutput;
        private IMessageDispatcher messageDispatcher = new MessageDispatcher();
        private GameNumberProvider numberProvider = new GameNumberProvider();

        private GameEngine(Helper helper, ICalculateBullsAndCowsStrategy calculateBullsAndCowsStrategy, InputOutput inputOutput)
        {
            this.attempts = 0;
            this.helper = helper;
            this.generatedNumber = this.numberProvider.Generate(DefaultNumberLength);
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

        public Helper Helper
        {
            get
            {
                return this.helper;
            }
        }

        public bool GameOn
        {
            get
            {
                return this.gameOn;
            }
        }

        public IMessageDispatcher MessageDispatcher
        {
            get
            {
                return this.messageDispatcher;
            }
        }

        public GameNumberProvider NumberProvider
        {
            get
            {
                return this.numberProvider;
            }
        }

        public void Start()
        {
            this.inputOutput.WriteLine(this.MessageDispatcher.GetWelcomeMessage());

            while (this.gameOn)
            {
                this.inputOutput.Write(this.MessageDispatcher.GetEnterCommandMessage());

                string playerInput = this.inputOutput.ReadLine();

                if (this.numberProvider.IsItValid(playerInput, DefaultNumberLength))
                {
                    int bullsCount;
                    int cowsCount;
                    this.attempts++;

                    this.calculateBullsAndCowStrategy.ExecuteStrategy(playerInput, this.generatedNumber, out bullsCount, out cowsCount);

                    if (bullsCount == DefaultNumberLength)
                    {
                        this.inputOutput.WriteLine(this.MessageDispatcher.GetCongatulationsMessage(this.helper, this.attempts));
                        this.FinishGame();
                    }
                    else
                    {
                        this.inputOutput.WriteLine(this.MessageDispatcher.GetWrongNumberMessage(bullsCount, cowsCount));
                    }
                }
                else
                {
                    Command playerCommand = this.commandCreator.Create(playerInput, game);
                    playerCommand.Execute(inputOutput);
                }
            }            
        }

        public void Exit()
        {
            this.gameOn = false;
            this.inputOutput.WriteLine(this.MessageDispatcher.GetGoodbyeMessage());
        }

        public void Restart()
        {
            this.attempts = 0;
            this.helper.Cheats = 0;
            this.generatedNumber = this.numberProvider.Generate(DefaultNumberLength);
            this.Start();
        }

        public string GetHelp()
        {
            return this.helper.GetHelp(this.generatedNumber);
        }

        public LeaderBoard<Player> GetScoreBoard()
        {
            return this.leaderBoard;
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

        private void AddPlayerToScoreboard(string playerName)
        {
            Player player = new Player(playerName, this.attempts);
            this.leaderBoard.Add(player);
        }
    }
}
