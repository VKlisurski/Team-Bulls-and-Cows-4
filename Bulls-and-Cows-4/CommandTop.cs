namespace BullsAndCowsGame
{
    internal class CommandTop : Command
    {
        public CommandTop(GameEngine engine) :
            base(engine)
        {
        }

        public override void Execute()
        {
            InputOutput inputOutput = new InputOutput();
            LeaderBoard<Player> leaderboard = Engine.GetScoreBoard;

            inputOutput.WriteLine(Message.GetScoreBoard(leaderboard));
        }
    }
}
