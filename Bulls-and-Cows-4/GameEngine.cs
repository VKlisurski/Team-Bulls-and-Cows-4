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
            this.generatedNumber = GameNumber.Generate(DefaultNumberLength);
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

        internal LeaderBoard<Player> GetScoreBoard
        {
            get
            {
                return this.leaderBoard;
            }
        }

        public void Start()
        {
            this.inputOutput.WriteLine(Message.WelcomeMessage());

            while (this.gameOn)
            {
                this.inputOutput.Write(Message.EnterCommand());

                string playerInput = this.inputOutput.ReadLine();

                if (GameNumber.IsItValid(playerInput, DefaultNumberLength))
                {
                    int bullsCount;
                    int cowsCount;
                    this.attempts++;

                    this.calculateBullsAndCowStrategy.ExecuteStrategy(playerInput, this.generatedNumber, out bullsCount, out cowsCount);

                    if (bullsCount == DefaultNumberLength)
                    {
                        this.inputOutput.WriteLine(Message.Congratulate(this.helper, this.attempts));
                        this.FinishGame();
                    }
                    else
                    {
                        this.inputOutput.WriteLine(Message.WrongNumber(bullsCount, cowsCount));
                    }
                }
                else
                {
                    Command playerCommand = this.commandCreator.Create(playerInput, game);
                    playerCommand.Execute(inputOutput);
                }
            }

            this.inputOutput.WriteLine(Message.Goodbye());
        }

        internal void Exit()
        {
            this.gameOn = false;
        }

        internal void Restart()
        {
            this.attempts = 0;
            this.helper.Cheats = 0;
            this.generatedNumber = GameNumber.Generate(DefaultNumberLength);
            this.Start();
        }

        internal string GetHelp()
        {
            return this.helper.GetHelp(this.generatedNumber);
        }

        private void FinishGame()
        {
            if (this.helper.Cheats == 0)
            {
                this.inputOutput.Write(Message.EnterName());
                string playerName = this.inputOutput.ReadLine();
                this.AddPlayerToScoreboard(playerName);
                this.inputOutput.WriteLine(Message.GetScoreBoard(this.leaderBoard));
            }
            else
            {
                this.inputOutput.WriteLine(Message.NoCheaters());
            }

            this.Restart();
        }

        private void AddPlayerToScoreboard(string playerName)
        {
            Player player = new Player(playerName, this.attempts);
            this.leaderBoard.Add(player);
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
    }
}
